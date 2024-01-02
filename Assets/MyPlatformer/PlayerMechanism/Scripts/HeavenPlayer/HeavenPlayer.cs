using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeavenPlayer : BasePlayer
{
    public bool onGround;
     public override void Awake()
    {
        base.Awake();
    }
    public override void Start()
    {
        base.Start();
        playerStateMachine.Intialize(idleState);
        initalColor = _spriteRenderer.color;
    }

    public override void Update()
    {    
        base.Update();
        playerStateMachine.currentstate.PlayerUpdate();
        onGround = IsGrounded();
       
    }

    public override void setVelocity(float x , float y) => rg2D.velocity = new Vector2(x , y);
  
    public override void flipsprite(bool isflip) => _spriteRenderer.flipX = isflip;
   
    public override bool IsGrounded() => Physics2D.OverlapCircle(groundcheckpoint.position , 0.2f, mask);

    public override void Damage()
    {
        base.Damage();
        playerStateMachine.ChangeState(this.playerHurtState);
       
        
    }
    void IntialColor()
    {
        _spriteRenderer.color = initalColor;
    }

    public override void Isattacking()
    {
        base.Isattacking();
    }
}
