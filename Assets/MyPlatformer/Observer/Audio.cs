using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Audio : MonoBehaviour
{
    public AudioClip coinSound;

    private void OnEnable()
    {
        if (SignalManager.Instance != null) 
        {
            SignalManager.Instance.Subscribe<CystalCollectedSignal>(PlayCoinSound);
        }
    }

    private void PlayCoinSound(CystalCollectedSignal signal)
    {
        AudioSource.PlayClipAtPoint(coinSound, transform.position);
    }

    private void OnDisable()
    {
        if(SignalManager.Instance != null)
        {
            SignalManager.Instance.Unsubscribe <CystalCollectedSignal>(PlayCoinSound);
        }
      
    }
    
}
