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
    public EnemyShootState enemyShootState;
    public bool isFlip;

    public GameObject player;
    public bool isGround;
    public bool isWallDetected;
    public float attackDistance;
    public float distance;
    public float throwRadius;
    public List<GameObject> projectile = new List<GameObject>();
  
    float throwCountDowm;
    SpriteRenderer playersprite;
    public override void Awake()
    {
        base.Awake();
        enemyIdle = new EnemyIdle(this,enemyStateMachine,"Idle",this);
        enemyMove = new EnemyMove(this, enemyStateMachine, "Walk", this);
        enemyBattleState = new EnemyBattleState(this, enemyStateMachine, "Walk", this);
        enemyAttackState = new EnemyAttackState(this, enemyStateMachine, "Attack", this);
        enemyStunnedState = new EnemyStunnedState(this, enemyStateMachine, "Hurt", this);
        enemyShootState = new EnemyShootState(this, enemyStateMachine, "Throw", this);
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

       

        throwCountDowm += Time.deltaTime;
       
        if (isPlayerRange() == true && throwCountDowm >5 )
        {
            ThrowProjectile(playerDir);

            throwCountDowm = 0;
        }
        
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
    RaycastHit2D isPlayerRange()
    {
        return Physics2D.Raycast(this.transform.position, Vector2.right *playerDir, throwRadius, playerLayerMask);

    }
    public void ThrowProjectile(float dir)
    {
        int RandomProjectile = Random.Range(0, projectile.Count);
        GameObject FireBall = Instantiate(projectile[RandomProjectile], playerDetected.transform.position, projectile[RandomProjectile].transform.rotation);
        FireBall.GetComponent<Rigidbody2D>().velocity = new Vector2(20.0f*playerDir, 0);
       
    }

    public override void OnDrawGizmos()
    {
        base.OnDrawGizmos();

        Gizmos.DrawLine(this.transform.position,this.transform.position + new Vector3(throwRadius*playerDir,0,0) );
    }

}
