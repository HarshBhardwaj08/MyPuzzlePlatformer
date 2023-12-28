using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmasherNotifier : MonoBehaviour
    
{
 
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            SignalManager.Instance.Notify("Smasher");
           
        }
       
    }
}
