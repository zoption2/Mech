using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class MechState : State
{
    public MechState(Mech character, StateMachine stateMachine) : base(character, stateMachine)
    {

    }

    protected abstract MechStates State { get;}
}
