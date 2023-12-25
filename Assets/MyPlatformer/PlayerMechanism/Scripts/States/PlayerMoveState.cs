using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoveState : PlayerGroundedState
{
    public PlayerMoveState(BasePlayer player, PlayerStateMachine stateMachine, string animBoolName) : base(player, stateMachine, animBoolName)
    {
    }

    public override void playerEnter()
    {
        base.playerEnter();
        
    }

    public override void playerExit()
    {
        base.playerExit();
    }

    public override void PlayerUpdate()
    {

        base.PlayerUpdate();
        player.flipsprite(flipSprite);
        player.setVelocity((InputX * player.moveSpeed), rg2d.velocity.y);
        if (InputX == 0)
        {
            stateMachine.ChangeState(player.idleState);
        }
       
    }
}
