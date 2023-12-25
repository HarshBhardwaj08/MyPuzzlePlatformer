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
       
    }

    public virtual void playerExit()
    {
        player.animator.SetBool(animboolname, false);
        
    }

    public virtual void PlayerUpdate()
    {
        InputX = Input.GetAxisRaw("Horizontal");
        flipSprite = (InputX >= 0) ? true : false;

    }
}
