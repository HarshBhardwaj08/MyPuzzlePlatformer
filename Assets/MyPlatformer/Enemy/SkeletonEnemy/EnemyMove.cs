using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : EnemyGroundedState
{
   
    public EnemyMove(Enemy enemy, EnemyStateMachine enemyStateMachine, string animName, SkeletonEnemy skeletonEnemy) : base(enemy, enemyStateMachine, animName, skeletonEnemy)
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
       
        skeletonEnemy.setVelocity(2.0f*faceDir, 0f);
        if(skeletonEnemy.IsWallDetected()== true || !skeletonEnemy.IsGrounded() )
        {
            enemy.flipsprite(flip);
            enemystateMachine.ChangeState(skeletonEnemy.enemyIdle);
        }
    }
   
}
