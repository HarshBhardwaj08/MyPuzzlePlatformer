using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour, IObserver
{
    protected int score {  get;  set; }
    public static UIManager instance;
    public Text Scoretext;
    protected ScoreKeepers scoreKeepers;
    public virtual void Awake()
    {   
        score = 0;
       instance = this;
        
    }
    public virtual void OnEnable()
    {
          
    }
    public virtual void getUpdate(string signal)
    {
       
    }
  
    public virtual void OnDisable()
    {
        
    }

}
