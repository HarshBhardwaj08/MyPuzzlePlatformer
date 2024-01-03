using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordController : MonoBehaviour
{
    Rigidbody2D rb2d;
    Animator animator;
    BasePlayer player;
    CircleCollider2D circleCollider2D;

    private void Awake()
    {
        rb2d = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        circleCollider2D = GetComponent<CircleCollider2D>();
    }
    public void SetDirection(Vector2 dir, float gravityscale)
    {
        rb2d.velocity = dir;
        rb2d.gravityScale = gravityscale;

    }
}
