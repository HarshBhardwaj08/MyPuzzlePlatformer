using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class PlayerCatchState : PlayerState
{
    public PlayerCatchState(BasePlayer player, PlayerStateMachine stateMachine, string animBoolName) : base(player, stateMachine, animBoolName)
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
    }
}
