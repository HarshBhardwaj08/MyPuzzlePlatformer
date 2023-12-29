using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Entity : MonoBehaviour
{
    public SpriteRenderer _spriteRenderer { get; set; }
    public Animator animator { get; set; }
    public Rigidbody2D rg2D { get; set; }
    public float moveSpeed;
    public float jumpforce;
    public bool isGrd;
    public LayerMask mask;
    public Transform groundcheckpoint;
    public virtual void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        rg2D = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }
  public virtual  void Start()
    {
        
    }

    // Update is called once per frame
  public virtual  void Update()
    {
        
    }
    public virtual void setVelocity(float x, float y) => rg2D.velocity = new Vector2(x, y);

    public virtual void flipsprite(bool isflip) => _spriteRenderer.flipX = isflip;

    public virtual bool IsGrounded() => Physics2D.OverlapCircle(groundcheckpoint.position, 0.2f, mask);
}
