using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreKeepers : MonoBehaviour
{
   public static ScoreKeepers instance;

    public int GemPoints;
    public int CystalPoints;
    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
    }
}
