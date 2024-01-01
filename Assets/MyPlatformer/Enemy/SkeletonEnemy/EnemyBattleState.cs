using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBattleState : EnemyState
{
    SkeletonEnemy skeletonEnemy;
    public EnemyBattleState(Enemy enemy, EnemyStateMachine enemyStateMachine, string animName, SkeletonEnemy skeletonEnemy) : base(enemy, enemyStateMachine, animName)
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
