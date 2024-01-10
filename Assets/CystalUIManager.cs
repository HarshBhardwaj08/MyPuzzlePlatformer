using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CystalUIManager : MonoBehaviour
{
    public Text CystalScore;
    private void OnEnable()
    {
        SignalManager.Instance.Subscribe<UpdateCystalUI>(updateCystalScore);
    }

    private void updateCystalScore(UpdateCystalUI uI)
    {
        CystalScore.text = "Score : " + uI.CystalScore.ToString();
    }

    private void OnDisable()
    {
        SignalManager.Instance.Unsubscribe<UpdateCystalUI>(updateCystalScore);
    }

}
