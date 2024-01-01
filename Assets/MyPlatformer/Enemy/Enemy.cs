using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Entity
{
    protected EnemyStateMachine enemyStateMachine { get; private set; }
    public EnemyState enemyState { get; set; }
    public Transform playerDetected;
    public float vision;
    public bool playerSeen;
    public LayerMask playerLayerMask; 
    public override void Awake()
    { 
       
        base.Awake();
        enemyStateMachine = new EnemyStateMachine();
    }
    public override void Start()
    {
        base.Awake();
      
    }
   public override void Update()
    {
        base.Update();
        enemyStateMachine.currentenemyState.PlayerUpdate();
       

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
 
}
