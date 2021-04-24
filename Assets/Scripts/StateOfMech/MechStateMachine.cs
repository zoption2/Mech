using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MechStateMachine : StateMachine
{
    private MechStates state;
    public MechStates State 
    {
        get => state;
        private set => state = value;
    }


    public void Initialize(MechState startingState) 
    {
        base.Initialize(startingState);
        State = startingState.State;
    }

    public void ChangeState(MechState newState)
    {
        base.ChangeState(newState);
        State = newState.State;
    }
}
