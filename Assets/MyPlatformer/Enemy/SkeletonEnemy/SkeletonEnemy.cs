using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkeletonEnemy : Enemy
{
    public EnemyIdle enemyIdle;
    public EnemyMove enemyMove;
    public bool isFlip;
    public float playerDir;
    public bool isGround;
    public bool isWallDetected;

    public override void Awake()
    {
        base.Awake();
        enemyIdle = new EnemyIdle(this,enemyStateMachine,"Idle",this);
        enemyMove = new EnemyMove(this, enemyStateMachine, "Walk", this);
    }

   

    public override void Start()
    {
        base.Start();
        enemyStateMachine.EnterState(enemyIdle);
    }

    public override void Update()
    {
        base.Update();
       isGround = IsGrounded();
       isWallDetected = IsWallDetected();
        playerSeen = isPlayerDetected();
    }
    public virtual bool isPlayerDetected()
    {   
        if(enemyMove.faceDir > 0)
        {
            return Physics2D.Raycast(playerDetected.position, Vector2.left, vision, playerLayerMask);
        }
        else
        {
            return Physics2D.Raycast(playerDetected.position, Vector2.left, -vision, playerLayerMask);
        }

    }
   
}
