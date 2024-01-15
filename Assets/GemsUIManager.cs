using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class GemsUIManager : MonoBehaviour
{
    public Text Scoretext;
  
    private void OnEnable()
    {
        SignalManager.Instance.Subscribe<UpdateGemsUISignal>(UpdateGemsUI);
    }

    private void UpdateGemsUI(UpdateGemsUISignal signal)
    {
        Scoretext.text = "Gems : " + signal.gemScore.ToString();
    }
    private void OnDisable()
    {
        SignalManager.Instance.Unsubscribe<UpdateGemsUISignal>(UpdateGemsUI);
    }
}
