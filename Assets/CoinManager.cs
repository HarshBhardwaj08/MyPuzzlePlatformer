using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinManager : UIManager
{
    public override void Awake()
    {
        base.Awake();
      
        score = 0;
       
    }
    private void Start()
    {
       
    }
    public override void OnEnable()
    {
        base.OnEnable();
        SignalManager.Instance.SubscribeToPublishers(this);
    }

    public override void getUpdate(string signal)
    {
        base.getUpdate(signal);

        if (signal == "CoinCollected")
        {
          
            int gempoints = ScoreKeepers.instance.GemPoints;
            score = score + gempoints;
            Scoretext.text = "Score: " + score.ToString();
            SignalManager.Instance.Notify("Collectables");

        }
    }
    public int getCoinScore()
    {
        return score;
    }
    public override void OnDisable()
    {
        base.OnDisable();
        SignalManager.Instance.UnSubscribeToPublishers(this);
    }

}
