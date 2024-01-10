using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gems : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            SignalManager.Instance.Fire(new GemsCollectedSignal() { GemPoints = 2});
            Destroy(this.gameObject);
        }
    }
}
