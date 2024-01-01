using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasePlayer :Entity
{
    

    #region States
    public PlayerIdleState idleState { get; set; }
    public PlayerMoveState moveState { get;  set; }
    public PlayerJump jumpstate { get; set; }
    public PlayerAirState airState { get;  set; }
    public PlayerStateMachine playerStateMachine { get; set; }
    public PlayerAttackState attackState { get; set; }
    #endregion

  protected HellPlayer hellPlayer { get; set; }
  protected HeavenPlayer heavenPlayer { get; set; }  

 
   
    public override void Awake()
    {
        base.Awake();
        playerStateMachine = new PlayerStateMachine();
        idleState = new PlayerIdleState(this, playerStateMachine, "Idle");
        moveState = new PlayerMoveState(this, playerStateMachine, "Move");
        jumpstate = new PlayerJump(this, playerStateMachine, "Jump");
        airState = new PlayerAirState(this, playerStateMachine, "Jump");
        attackState = new PlayerAttackState(this, playerStateMachine, "Attack");
    }

    public override void Start()
    {
        base.Start();
        playerStateMachine.Intialize(idleState);
    }

   public override void Update()
    {
        base.Update();
        playerStateMachine.currentstate.PlayerUpdate();
       
      
    }
    
    public override void setVelocity(float x, float y) => rg2D.velocity = new Vector2(x, y);

    public override void flipsprite(bool isflip) => _spriteRenderer.flipX = isflip;

    public override bool IsGrounded() => Physics2D.OverlapCircle(groundcheckpoint.position, 0.2f, mask);

    public virtual void Isattacking()
    {
        playerStateMachine.currentstate.IsAttacking();
    }

}
