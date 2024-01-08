using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkeletonEnemy : Enemy
{
    public EnemyIdle enemyIdle;
    public EnemyMove enemyMove;
    public EnemyAttackState enemyAttackState;
    public EnemyBattleState enemyBattleState;
    public EnemyStunnedState enemyStunnedState;
    public bool isFlip;
  
    public bool isGround;
    public bool isWallDetected;
    public float attackDistance;
    public float distance;
   
    public override void Awake()
    {
        base.Awake();
        enemyIdle = new EnemyIdle(this,enemyStateMachine,"Idle",this);
        enemyMove = new EnemyMove(this, enemyStateMachine, "Walk", this);
        enemyBattleState = new EnemyBattleState(this, enemyStateMachine, "Walk", this);
        enemyAttackState = new EnemyAttackState(this, enemyStateMachine, "Attack", this);
        enemyStunnedState = new EnemyStunnedState(this, enemyStateMachine, "Hurt", this);
    }

   

    public override void Start()
    {
        base.Start();
        enemyStateMachine.EnterState(enemyIdle);
        initalColor = _spriteRenderer.color;

    }

    public override void Update()
    {
        base.Update();

        if(freeze == true)
        {
            enemyStateMachine.ChangeState(this.enemyIdle);
        }
       isGround = IsGrounded();
       isWallDetected = IsWallDetected();
       playerSeen = isPlayerDetected();
        
    }
    
    public override void onAttack()
    {
        base.onAttack();
    }

    public override void Damage()
    {
        base.Damage();
        enemyStateMachine.ChangeState(this.enemyStunnedState);
        setVelocity(knockback.x,knockback.y);
      
    }
    
}
