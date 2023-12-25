using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private List<Coin> coinList = new List<Coin>();
   
    public UIManager manager;
    public Audio audios;

    private void Awake()
    {
       
        GameObject[] coins = GameObject.FindGameObjectsWithTag("Coins");
        foreach (GameObject coin in coins)
        {
            Coin coinComponent = coin.GetComponent<Coin>();
            if (coinComponent != null)
            {
                coinList.Add(coinComponent);
            }
        }
    }

    void Start()
    {
       
        foreach (Coin coin in coinList)
        {
            coin.add(manager);
            coin.add(audios);
        }
    }


}
