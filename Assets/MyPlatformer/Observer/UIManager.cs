using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour,IObserver
{

    public Text Scoretext;
    public int score;
   
    public void getUpdate()
    {
        Debug.Log("UiUpdated");
        score++;
        Scoretext.text = "Score: " + score.ToString(); 
    }
}
