using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloneController : MonoBehaviour
{
    Rigidbody2D rb2D;
    Animator animator;
    private void Awake()
    {
        rb2D = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {   

        rb2D.velocity = new Vector2(1,0);
        animator.SetBool("Run", true);
    }
}
