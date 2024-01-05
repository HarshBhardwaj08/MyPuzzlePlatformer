using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    private int score = 0;
    public static UIManager instance;
    public Text Scoretext;

    private void Awake()
    {
        instance = this;
    }


    private void OnEnable()
    {
      //  SignalManager.Instance.SubscribeToPublishers(this);
    }

    

    public void UpdateScore(int score)
    {
        Scoretext.text = "Score: " + ScoreKeeper.Instance.GetScore();
    }

    public int GetScore()
    {
        return score;
    }


    private void OnDisable()
    {
      //  SignalManager.Instance.UnSubscribeToPublishers(this);
    }

}

public class ScoreKeeper : IObserver
{
    private UIManager uIManager = new UIManager();

    public static ScoreKeeper Instance
    {
        get
        {
            if (instance == null)
                instance = new ScoreKeeper();
            return instance;

        }
    }

    private static ScoreKeeper instance;
    private int score = 0;

    public void getUpdate(string signal)
    {
        Debug.Log("Inside");
       if(signal == "CoinCollected")
        {
            score++;
            Debug.Log("InScoreKeeper");
            uIManager.UpdateScore(score);
        }
    }

    public int GetScore()
    {
        return score;
    }
}
