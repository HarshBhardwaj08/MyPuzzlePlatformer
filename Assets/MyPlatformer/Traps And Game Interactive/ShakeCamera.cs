using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using System;

public class ShakeCamera : MonoBehaviour
{
    public CinemachineVirtualCamera cinemachineVirtualCamera; 
    public float shakeIntensity = 1.0f;
    public float shakeDuration = 0.5f;
    private void OnEnable()
    {
        SignalManager.Instance.Subscribe<CameraShakerSignal>(getUpdate);
    }

    private void getUpdate(CameraShakerSignal signal)
    {
        ShakesCamera();
    }

    private void OnDisable()
    {
        SignalManager.Instance.Unsubscribe<CameraShakerSignal>(getUpdate);
    }

    void Start()
    {
       
        if (cinemachineVirtualCamera == null)
        {
            Debug.LogError("CinemachineVirtualCamera component not assigned!");
        }
    }

   
    void ShakesCamera()
    {
      
        CinemachineBasicMultiChannelPerlin noise = cinemachineVirtualCamera.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();

        if (noise != null)
        {
            noise.m_AmplitudeGain = shakeIntensity;
            noise.m_FrequencyGain = 5f; 
            Invoke("StopShake", shakeDuration);
        }
    }

    void StopShake()
    {
      
        CinemachineBasicMultiChannelPerlin noise = cinemachineVirtualCamera.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
        if (noise != null)
        {
            noise.m_AmplitudeGain = 0f;
            noise.m_FrequencyGain = 0f;
        }
    }
}
