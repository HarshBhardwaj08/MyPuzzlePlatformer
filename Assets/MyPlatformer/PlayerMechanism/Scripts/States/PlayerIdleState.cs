using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerIdleState : PlayerGroundedState
{
    public PlayerIdleState(BasePlayer player, PlayerStateMachine stateMachine, string animBoolName) : base(player, stateMachine, animBoolName)
    {

    }

    public override void playerEnter()
    {
        base.playerEnter();
        player.flipsprite(flipSprite);
    }

    public override void playerExit()
    {
        base.playerExit();
    }

    public override void PlayerUpdate()
    {
        base.PlayerUpdate();
       
        if (InputX != 0)
        {
            stateMachine.ChangeState(player.moveState);
        }
    }
}
