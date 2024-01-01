using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttackState : EnemyState
{
    SkeletonEnemy skeletonEnemy;

    public EnemyAttackState(Enemy enemy, EnemyStateMachine enemyStateMachine, string animName,SkeletonEnemy skeletonEnemy) : base(enemy, enemyStateMachine, animName)
    {
        this.skeletonEnemy = skeletonEnemy;
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
