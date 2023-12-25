using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : Publishers
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            Notify();
         // Destroy(this.gameObject);
          this.gameObject.SetActive(false); 
        }
    }
}
