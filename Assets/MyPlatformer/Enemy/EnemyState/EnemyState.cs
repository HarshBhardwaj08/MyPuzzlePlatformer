using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Windows;

public class EnemyState
{
    public EnemyStateMachine enemystateMachine;
    public Enemy enemy;
    string animationAName;
    public bool triggredCalled;
    public bool flip;
    protected float stateTimer;
    public float faceDir;

    public EnemyState()
    {

    }
    public EnemyState(Enemy enemy , EnemyStateMachine enemyStateMachine , string animName)
    {
        this.enemy = enemy;
        this.enemystateMachine = enemyStateMachine;
        this.animationAName = animName;
    }


    public virtual void playerEnter()
    {
        triggredCalled = false;
       enemy.animator.SetBool(animationAName, true);
    }

    public virtual void playerExit()
    {
       enemy.animator.SetBool(animationAName , false);

    }

    public virtual void PlayerUpdate()
    {

        stateTimer -= Time.deltaTime;
        flipCHecker();

    }
   public virtual void flipCHecker()
    {
        if (enemy.rg2D.velocity.x >= 0)
        {
            flip = true;
            faceDir = 1;
        }
        else if (enemy.rg2D.velocity.x <= 0)
        {
            flip = false;
            faceDir = -1;
        }
    }
    
    
     public virtual void IsAttacking() => triggredCalled = true;

}
