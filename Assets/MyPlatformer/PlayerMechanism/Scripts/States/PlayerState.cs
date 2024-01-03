using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerState 
{
    protected PlayerStateMachine stateMachine;
    public BasePlayer player;
    protected float InputX;
    string animboolname;
    protected Rigidbody2D rg2d;
    protected bool flipSprite;
    protected bool isAttacking;
    protected float stunnedTime;

    public PlayerState(BasePlayer player,PlayerStateMachine stateMachine , string animBoolName)
    {
        this.player = player;
        this.stateMachine = stateMachine;
        this.animboolname = animBoolName;
    }
   
    public virtual void playerEnter()
    {
       
        player.animator.SetBool(animboolname, true);
        rg2d = player.rg2D;
        isAttacking = false;
       
    }

    public virtual void playerExit()
    {
        player.animator.SetBool(animboolname, false);
        
    }

    public virtual void PlayerUpdate()
    {
        InputX = Input.GetAxis("Horizontal");
        if(InputX != 0)
        flipSprite = (InputX >= 0);
     
    }
    public virtual void IsAttacking() => isAttacking = true;
}
