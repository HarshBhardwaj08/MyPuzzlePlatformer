using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasePlayer : MonoBehaviour
{
    public SpriteRenderer _spriteRenderer { get; set; }
    public Animator animator { get; set; }
    public Rigidbody2D rg2D { get;  set; }

    public float moveSpeed;
    public float jumpforce;
    public int extraJump;
    public bool isGrd;

    #region States
    public PlayerIdleState idleState { get; set; }
    public PlayerMoveState moveState { get;  set; }
    public PlayerJump jumpstate { get; set; }
    public PlayerAirState airState { get;  set; }
    public PlayerStateMachine playerStateMachine { get; set; }
    #endregion

  protected HellPlayer hellPlayer { get; set; }
  protected HeavenPlayer heavenPlayer { get; set; }  

    public LayerMask mask;
    public Transform groundcheckpoint;
    public virtual void Awake()
    {
        playerStateMachine = new PlayerStateMachine();
        idleState = new PlayerIdleState(this, playerStateMachine, "Idle");
        moveState = new PlayerMoveState(this, playerStateMachine, "Move");
        jumpstate = new PlayerJump(this, playerStateMachine, "Jump");
        airState = new PlayerAirState(this, playerStateMachine, "Jump");

    }

    public virtual void Start()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        rg2D = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        playerStateMachine.Intialize(idleState);
    }

   public virtual void Update()
    {
        playerStateMachine.currentstate.PlayerUpdate();
        isGrd = IsGrounded();
    }

    public virtual void setVelocity(float x, float y) => rg2D.velocity = new Vector2(x, y);

    public virtual void flipsprite(bool isflip) => _spriteRenderer.flipX = isflip;

    public virtual bool IsGrounded() => Physics2D.OverlapCircle(groundcheckpoint.position, 0.2f, mask);

}
