using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSwordThrowState : PlayerState
{
    public PlayerSwordThrowState(BasePlayer player, PlayerStateMachine stateMachine, string animBoolName) : base(player, stateMachine, animBoolName)
    {
    }

    public override void playerEnter()
    {
        base.playerEnter();
        //sword
        
    }

    public override void playerExit()
    {
        base.playerExit();
    }

    public override void PlayerUpdate()
    {
        base.PlayerUpdate();
        if (Input.GetKeyUp(KeyCode.Mouse1))
        {
            stateMachine.ChangeState(player.idleState);
        }
    }
}
