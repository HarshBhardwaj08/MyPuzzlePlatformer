using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGroundedState : EnemyState
{
   protected SkeletonEnemy skeletonEnemy;
    public EnemyGroundedState(Enemy enemy, EnemyStateMachine enemyStateMachine, string animName, SkeletonEnemy skeletonEnemy) : base(enemy, enemyStateMachine, animName)
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
        if (skeletonEnemy.isPlayerDetected() == true && Vector2.Distance(skeletonEnemy.transform.position, skeletonEnemy.transform.position)  < 2.0f)
        {
            enemystateMachine.ChangeState(skeletonEnemy.enemyBattleState);
        }
    }
}
