using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class StateMachine
{
    public State CurrentState;

    public virtual void Initialize(State startingState)
    {
        CurrentState = startingState;
        startingState.Enter();
    }

    public virtual void ChangeState(State newState)
    {
        CurrentState.Exit();
        CurrentState = newState;
        newState.Enter();
    }
}
