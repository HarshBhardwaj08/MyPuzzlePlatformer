using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CystalManager : SingleteornClass<CystalManager>
{
    int score;
    protected override void Awake()
    {
        base.Awake();
        score = 0;
        //if(ExtractJson.instance.data != null)
        //{
        //    score = ExtractJson.instance.data.cystalCollected;
        //    Scoretext.text = "Score: " + score.ToString();
        //}
    }

    public void OnEnable()
    {
       SignalManager.Instance.Subscribe<CystalCollectedSignal>(OnCystalCollected);
    }

    public  void OnDisable()
    {
       
        SignalManager.Instance.Unsubscribe<CystalCollectedSignal>(OnCystalCollected);
    }

    public void OnCystalCollected(CystalCollectedSignal signal)
    {
        
        score = signal.count + score;
        SignalManager.Instance.Fire(new UpdateCystalUI() { CystalScore = score});
        SignalManager.Instance.Fire(new AudioNotify());
       
    }

 
    public int getCystalScore()
    {
        return score;
    }
   

}
