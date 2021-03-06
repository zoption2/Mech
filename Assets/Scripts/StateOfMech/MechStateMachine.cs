using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MechStateMachine : StateMachine
{
    public new MechState CurrentState;

    private MechStates state;
    public MechStates State 
    {
        get => state;
        private set => state = value;
    }


    public virtual void Initialize(MechState startingState) 
    {
        CurrentState = startingState;
        startingState.Enter();
        State = startingState.State;
    }

    public virtual void ChangeState(MechState newState)
    {
        CurrentState.Exit();
        CurrentState = newState;
        newState.Enter();
        State = newState.State;
    }
}
