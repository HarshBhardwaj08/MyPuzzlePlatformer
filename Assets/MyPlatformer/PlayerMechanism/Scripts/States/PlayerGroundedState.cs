using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGroundedState : PlayerState
{

    public PlayerGroundedState(BasePlayer player, PlayerStateMachine stateMachine, string animBoolName) : base(player, stateMachine, animBoolName)
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
        if (Input.GetKeyDown(KeyCode.Space) && player.IsGrounded() == true) { stateMachine.ChangeState(player.jumpstate); }

        if (Input.GetKeyDown(KeyCode.Mouse0)) { stateMachine.ChangeState(player.attackState); }
        if(Input.GetKey(KeyCode.Mouse1))
        {
            stateMachine.ChangeState(player.PlayerSwordThrowState);
        }
      
    }
}
