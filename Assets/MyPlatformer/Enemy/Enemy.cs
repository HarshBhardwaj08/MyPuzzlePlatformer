using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Entity
{
    protected EnemyStateMachine enemyStateMachine { get; private set; }
    public EnemyState enemyState { get; set; }
    public Transform playerDetected;
    public float vision;
    protected bool playerSeen;
    public Vector2 knockback;
    public LayerMask playerLayerMask;
    public bool freeze;
    public override void Awake()
    { 
       
        base.Awake();
        enemyStateMachine = new EnemyStateMachine();
        enemyState = new EnemyState();
    }
    public override void Start()
    {
        base.Awake();
      
      
    }
   public override void Update()
    {
        base.Update();
        if(freeze == false)
        {
            enemyStateMachine.currentenemyState.PlayerUpdate();
        }
       
       

    }
    public override void flipsprite(bool isflip)
    {

        if (isflip == true)
        {
            this.transform.localScale = new Vector3(-1, transform.localScale.y, transform.localScale.z);
        }
        else
        {
            this.transform.localScale = new Vector3(1, transform.localScale.y, transform.localScale.z);
        }
    }
    
    public virtual void onAttack()
    {
        enemyStateMachine.currentenemyState.IsAttacking(); 
    }
    public virtual RaycastHit2D isPlayerDetected()
    {
        return Physics2D.Raycast(playerDetected.position, Vector2.right * enemyState.faceDir, vision, playerLayerMask);

    }
   
    public virtual void ZeroVelocity() => rg2D.velocity = new Vector2(0, 0);

    public virtual void freezeEnemy(bool freeze)
    {
        this.freeze = freeze;
    }
    public override void AttackArea()
    {

        Collider2D[] collider2Ds = Physics2D.OverlapCircleAll(attackpoint.transform.position, AttackRadius);

        foreach (var hit in collider2Ds)
        {
            if (hit.gameObject.tag == "Player")
                hit.gameObject.GetComponent<BasePlayer>().Damage();
        }
    }
    
    public override void Damage()
    {
        Debug.Log(this.gameObject + "50");
    }
    public override void OnDrawGizmos()
    {
       
        Gizmos.DrawWireSphere(attackpoint.transform.position, AttackRadius);
    }
}
