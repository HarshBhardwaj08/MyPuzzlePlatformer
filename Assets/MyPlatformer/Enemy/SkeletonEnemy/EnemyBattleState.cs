using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBattleState : EnemyState
{
    SkeletonEnemy skeletonEnemy;
    Transform player;
    public EnemyBattleState(Enemy enemy, EnemyStateMachine enemyStateMachine, string animName, SkeletonEnemy skeletonEnemy) : 
        base(enemy, enemyStateMachine, animName)
    {
        this.skeletonEnemy = skeletonEnemy;
    }

    public override void playerEnter()
    {
        base.playerEnter();
        player = GameObject.Find("Player1").transform;
    }

    public override void playerExit()
    {
        base.playerExit();
    }

    public override void PlayerUpdate()
    {
        base.PlayerUpdate();
        if (enemy.isPlayerDetected())
        {
            if (enemy.isPlayerDetected().distance < skeletonEnemy.attackDistance)
            {

                skeletonEnemy.setVelocity(0, 0);
                enemystateMachine.ChangeState(skeletonEnemy.enemyAttackState);
            }
        }

       

        checkflip();
    }
   void checkflip()
    {

        if (player.transform.position.x > skeletonEnemy.transform.position.x)
        {
            faceDir = 1;
            flip = false;
        }
        else if (player.transform.position.x < skeletonEnemy.transform.position.x)
        {
            faceDir = -1;
            flip = true;
        }
        enemy.flipsprite(flip);
        skeletonEnemy.setVelocity(faceDir * skeletonEnemy.moveSpeed, skeletonEnemy.rg2D.velocity.y);
    }

}
