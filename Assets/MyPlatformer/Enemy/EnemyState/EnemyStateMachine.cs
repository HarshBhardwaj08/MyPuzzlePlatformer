using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStateMachine
{
  public EnemyState currentenemyState { get; private set; }

  public void EnterState(EnemyState enemystate)
    {
        currentenemyState = enemystate;
        currentenemyState.playerEnter();
    }
    public void ChangeState(EnemyState enemyState)
    {
        currentenemyState.playerExit();
        currentenemyState = enemyState;
        currentenemyState.playerEnter();
    }
}
