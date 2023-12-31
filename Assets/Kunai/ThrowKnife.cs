using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowKnife : MonoBehaviour
{
    Rigidbody2D rg2d;
    private void Awake()
    {
        rg2d = GetComponent<Rigidbody2D>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Ground") 
        {  
            rg2d.velocity = Vector2.zero;  
           rg2d.isKinematic = true;
        }
    }
}
