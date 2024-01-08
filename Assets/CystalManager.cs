using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CystalManager : UIManager
{
    public override void Awake()
    {
        base.Awake();
        score = 0;
        if(ExtractJson.instance.data != null)
        {
            score = ExtractJson.instance.data.cystalCollected;
            Scoretext.text = "Score: " + score.ToString();
        }
    }
    public override void OnEnable()
    {
        base.OnEnable();
        SignalManager.Instance.SubscribeToPublishers(this);
    }

    public override void getUpdate(string signal)
    {
        base.getUpdate(signal);


            if (signal == "CystalCollected")
            {
                int cystalPoints = ScoreKeepers.instance.CystalPoints;
                score = cystalPoints + score;
                Scoretext.text = "Score: " + score.ToString();
                SignalManager.Instance.Notify("Collectables");
            }
        
    }
    public int getCystalScore()
    {
        return score;
    }
    public override void OnDisable()
    {
        base.OnDisable();
        SignalManager.Instance.UnSubscribeToPublishers(this);
    }
   
}
