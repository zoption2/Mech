using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveStateMachine : StateMachine
{
    public new MovementState CurrentState;

    private Movements state;
    public Movements State
    {
        get => state;
        private set => state = value;
    }

    public virtual void Initialize(MovementState startingState)
    {
        CurrentState = startingState;
        startingState.Enter();
        State = startingState.State;
    }

    public void ChangeState(MovementState newState)
    {
        CurrentState.Exit();
        CurrentState = newState;
        newState.Enter();
        State = newState.State;
    }
}
