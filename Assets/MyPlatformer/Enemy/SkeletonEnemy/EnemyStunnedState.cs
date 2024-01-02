using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStunnedState : EnemyState
{
    SkeletonEnemy skeletonEnemy;
    public EnemyStunnedState(Enemy enemy, EnemyStateMachine enemyStateMachine, string animName,SkeletonEnemy skeletonEnemy) : base(enemy, enemyStateMachine, animName)
    {
        this.skeletonEnemy = skeletonEnemy;
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
        stateTimer -= Time.deltaTime;
        if(stateTimer < 0)
        {
            enemystateMachine.ChangeState(skeletonEnemy.enemyIdle);
        }

    }
}
