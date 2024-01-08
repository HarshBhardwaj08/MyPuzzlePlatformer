using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloneController : MonoBehaviour
{
    Rigidbody2D rb2D;
    Animator animator;
    SpriteRenderer _SpriteRenderer;
    Enemy enemy;
    float waitTime;
    private void Awake()
    {
        rb2D = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        _SpriteRenderer = GetComponent<SpriteRenderer>();
    }
   

    // Update is called once per frame
    void Update()
    {
        waitTime += Time.deltaTime;
        if(waitTime >1.0f)
        MoveClone();
    }

    private void MoveClone()
    {
        if (rb2D == null) return;

        var direction = _SpriteRenderer.flipX ? 5 : -5;
        rb2D.velocity = new Vector2(direction, rb2D.velocity.y);
        animator.SetBool("Run", true);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Enemy")
        {
            Debug.Log("Hit");
            animator.SetBool("Run", false);
            animator.SetTrigger("Attack");
            enemy = collision.gameObject.GetComponent<Enemy>();
           
           
        }
        Destroy(this.gameObject, 3.0f);
    }
   

    public void onAttack()
    {
        enemy.Damage();
    }
    public void Destroy()
    {
        Destroy(this.gameObject);
    }
}
