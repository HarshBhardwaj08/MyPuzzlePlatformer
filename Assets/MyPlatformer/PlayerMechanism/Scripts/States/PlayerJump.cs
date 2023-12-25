using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJump : PlayerState
{
    public PlayerJump(BasePlayer player, PlayerStateMachine stateMachine, string animBoolName) : base(player, stateMachine, animBoolName)
    {

    }

    public override void playerEnter()
    {
        base.playerEnter();
       // player.hellPlayer.setVelocity(player.hellPlayer.rg2D.velocity.x, -player.jumpforce);
        player.setVelocity( rg2d.velocity.x, player.jumpforce);
    }

    public override void playerExit()
    {
        base.playerExit();
       
    }

    public override void PlayerUpdate()
    {
        base.PlayerUpdate();

        if(rg2d.velocity.y > 0)
        {
            stateMachine.ChangeState(player.airState);
        }
        
    }
}
