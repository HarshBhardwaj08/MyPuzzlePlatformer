using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHurtState : PlayerState
{
    public PlayerHurtState(BasePlayer player, PlayerStateMachine stateMachine, string animBoolName) : base(player, stateMachine, animBoolName)
    {
    }

    public override void playerEnter()
    {
        base.playerEnter();
        stunnedTime = 1f;
    }

    public override void playerExit()
    {
        base.playerExit();
    }

    public override void PlayerUpdate()
    {
        base.PlayerUpdate();
        stunnedTime -= Time.deltaTime;
        if(stunnedTime < 0)
        {
            stateMachine.ChangeState(player.idleState);
            
        }
    }
}
