using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class GemsUIManager : MonoBehaviour
{
    public Text Scoretext;
    private void Awake()
    {
        
    }
    private void OnEnable()
    {
        SignalManager.Instance.Subscribe<UpdateGemsUISignal>(UpdateGemsUI);
    }

    private void UpdateGemsUI(UpdateGemsUISignal signal)
    {
        Scoretext.text = "Gems : " + signal.gemScore.ToString();
    }
}
