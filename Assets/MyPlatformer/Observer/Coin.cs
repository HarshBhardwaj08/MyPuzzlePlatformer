using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            SignalManager.Instance.Notify("CoinCollected");
         // Destroy(this.gameObject);
          this.gameObject.SetActive(false); 
        }
    }
}
