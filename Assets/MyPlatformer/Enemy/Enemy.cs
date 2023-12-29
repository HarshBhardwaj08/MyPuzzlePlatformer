using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Entity
{
    protected EnemyStateMachine StateMachine { get; private set; }
    public override void Awake()
    {
        base.Awake();
    }
    public override void Start()
    {
        base.Awake();
        StateMachine = new EnemyStateMachine();

    }
   public override void Update()
    {
        base.Update();
        StateMachine.currentenemyState.PlayerUpdate();
    }
}
