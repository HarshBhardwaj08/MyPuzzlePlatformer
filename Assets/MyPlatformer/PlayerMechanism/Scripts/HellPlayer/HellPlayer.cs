using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HellPlayer : BasePlayer
{   
   public override void Awake()
    {  
        base.Awake();
        hellPlayer = GetComponent<HellPlayer>();
       

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
        isGrd = IsGrounded();
    }

    public override void setVelocity(float x, float y) => rg2D.velocity = new Vector2(x, y);

    public override void flipsprite(bool isflip) => _spriteRenderer.flipX = isflip;

    public override bool IsGrounded() => Physics2D.OverlapCircle(groundcheckpoint.position, 0.2f, mask);

    public override void Isattacking()
    {
        base.Isattacking();
    }
}
