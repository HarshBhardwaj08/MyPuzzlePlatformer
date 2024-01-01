using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyIdle : EnemyGroundedState
{
    public EnemyIdle(Enemy enemy, EnemyStateMachine enemyStateMachine, string animName, SkeletonEnemy skeletonEnemy) : base(enemy, enemyStateMachine, animName, skeletonEnemy)
    {
    }

    public override void playerEnter()
    {
        base.playerEnter();
        stateTimer = 1f;
    }

    public override void playerExit()
    {
        base.playerExit();
    }

    public override void PlayerUpdate()
    {
        base.PlayerUpdate();
        if(stateTimer < 0f)
        {
            enemystateMachine.ChangeState(skeletonEnemy.enemyMove);
        }
    }
}
