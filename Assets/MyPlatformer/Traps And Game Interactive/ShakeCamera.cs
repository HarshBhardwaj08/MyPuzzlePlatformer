using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class ShakeCamera : MonoBehaviour
{
    public CinemachineVirtualCamera cinemachineVirtualCamera; 
    public float shakeIntensity = 1.0f;
    public float shakeDuration = 0.5f;
    private void OnEnable()
    {
       // SignalManager.Instance.SubscribeToPublishers(this);
    }

    private void OnDisable()
    {
       // SignalManager.Instance.UnSubscribeToPublishers(this);
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

    public void getUpdate(string signal)
    {
       if(signal == "CameraShake")
        {
            ShakesCamera();
        }
    }
}
