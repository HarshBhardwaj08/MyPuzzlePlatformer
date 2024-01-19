using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerState 
{
    protected PlayerStateMachine stateMachine;
    public BasePlayer player;
    public float InputX;
    string animboolname;
    protected Rigidbody2D rg2d;
    protected bool flipSprite;
    protected bool isAttacking;
    protected float stunnedTime;
    protected float DeacivateKamui;

    public PlayerState(BasePlayer player,PlayerStateMachine stateMachine , string animBoolName)
    {
        this.player = player;
        this.stateMachine = stateMachine;
        this.animboolname = animBoolName;
    }
   
    public virtual void playerEnter()
    {
        DeacivateKamui = 0;
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
        DeacivateKamui += Time.deltaTime;
        if (DeacivateKamui >= 10.0f)
        {
          //  player.Kamui.SetActive(false);
            DeacivateKamui = 0;
        }

    }
    public virtual void IsAttacking() => isAttacking = true;
}
