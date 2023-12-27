using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Audio : MonoBehaviour, IObserver
{
    public AudioClip coinSound;

    private void OnEnable()
    {
        if (SignalManager.Instance != null)
        {
            SignalManager.Instance.SubscribeToPublishers(this);
        }
    }
    private void OnDisable()
    {
        if(SignalManager.Instance != null)
        {
            SignalManager.Instance.UnSubscribeToPublishers(this);
        }
      
    }
    public void getUpdate(string signal)
    {
        if(signal == "CoinCollected")
        PlayCoinSound();

    }
 

    void PlayCoinSound()
    {
        AudioSource.PlayClipAtPoint(coinSound, transform.position);
    }
}
