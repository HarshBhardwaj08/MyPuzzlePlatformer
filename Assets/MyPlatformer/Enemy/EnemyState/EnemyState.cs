using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Windows;

public class EnemyState
{
    public EnemyStateMachine stateMachine;
    public Enemy enemy;
    string animationAName;
    bool triggredCalled;
    protected float stateTimer;

    public EnemyState(Enemy enemy , EnemyStateMachine enemyStateMachine , string animName)
    {
        this.enemy = enemy;
        this.stateMachine = enemyStateMachine;
        this.animationAName = animName;
    }


    public virtual void playerEnter()
    {
        triggredCalled = false;
      

    }

    public virtual void playerExit()
    {
       

    }

    public virtual void PlayerUpdate()
    {

        stateTimer -= Time.deltaTime;
    }

    public virtual void IsAttacking() => triggredCalled = true;
}
