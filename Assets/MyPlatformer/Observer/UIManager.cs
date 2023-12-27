using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour,IObserver
{

    public Text Scoretext;
    public int score;
    private void OnEnable()
    {
        SignalManager.Instance.SubscribeToPublishers(this);
    }
    private void OnDisable()
    {
        SignalManager.Instance.UnSubscribeToPublishers(this);
    }
    public void getUpdate(string signal)
     {
        if(signal == "CoinCollected")
        {
            Debug.Log("UiUpdated");
            score++;
            Scoretext.text = "Score: " + score.ToString();
        }
        
    }
}
