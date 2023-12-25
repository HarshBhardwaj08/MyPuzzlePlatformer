using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStateMachine 
{
    public PlayerState currentstate { get; set; }

    public void Intialize(PlayerState _startState)
    {
        currentstate = _startState;
        currentstate.playerEnter();
    }
    public void ChangeState(PlayerState _newstate)
    {
        currentstate.playerExit();
        currentstate = _newstate;
        currentstate.playerEnter();
    }
}
