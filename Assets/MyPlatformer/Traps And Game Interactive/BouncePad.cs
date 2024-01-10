using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BouncePad : MonoBehaviour
{
    BasePlayer player;
    Animator animator;
    public float jumpHeight; 
    private void Awake()
    {
        animator = GetComponent<Animator>();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            player = collision.gameObject.GetComponent<BasePlayer>();
            animator.SetBool("Bounce", true);
            player.rg2D.AddForce(Vector2.up*jumpHeight, ForceMode2D.Impulse);
            player.playerStateMachine.ChangeState(player.moveState);
           
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Invoke("AnimOff", 1.0f);
        }
    }

   public void AnimOff()
    {
        animator.SetBool("Bounce", false);
        Debug.Log("False");
    }
}
