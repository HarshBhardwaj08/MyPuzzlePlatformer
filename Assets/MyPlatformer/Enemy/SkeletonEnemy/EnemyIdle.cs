using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyIdle : EnemyState
{
    
    public EnemyIdle(Enemy enemy, EnemyStateMachine enemyStateMachine, string animName) : base(enemy, enemyStateMachine, animName)
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
