using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cystal : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            SignalManager.Instance.Fire(new CystalCollectedSignal() { count = 1 });
            Destroy(this.gameObject);
        }
    }
}
