using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GemsManager : SingleteornClass<GemsManager>
{
    int score;
    
    protected override void Awake()
    {
        base.Awake();
        score = 0;
    }
    private void Start()
    {
        if (ExtractJson.instance.data != null)
        {
            score = ExtractJson.instance.data.gemCollected;
           //Scoretext.text = "Score: " + score.ToString();
        }

    }
    public  void OnEnable()
    {

        SignalManager.Instance.Subscribe<GemsCollectedSignal>(onCoinCollected);
    }

    public void OnDisable()
    {

        SignalManager.Instance.Unsubscribe<GemsCollectedSignal>(onCoinCollected);
    }

    private void onCoinCollected(GemsCollectedSignal signal)
    {
        score = signal.GemPoints + score;
        SignalManager.Instance.Fire(new UpdateGemsUISignal() { gemScore = score });
        SignalManager.Instance.Fire(new AudioNotify());
    }
    public int getGemsScore()
    {
        return score;
    }
   

}
