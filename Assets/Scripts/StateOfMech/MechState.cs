using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class MechState : State
{
    protected new Mech character;

    public abstract MechStates State { get; }

    public MechState(Mech character, StateMachine stateMachine) : base(character, stateMachine)
    {
        this.character = character;
    }

}
