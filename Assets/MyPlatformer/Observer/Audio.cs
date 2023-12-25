using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Audio : MonoBehaviour, IObserver
{
    public AudioClip coinSound;
    public void getUpdate()
    {
        PlayCoinSound();

    }
 

    void PlayCoinSound()
    {
        AudioSource.PlayClipAtPoint(coinSound, transform.position);
    }
}
