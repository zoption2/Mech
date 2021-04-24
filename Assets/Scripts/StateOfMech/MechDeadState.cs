using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MechDeadState : MechState
{
    public MechDeadState(Mech character, StateMachine stateMachine) : base(character, stateMachine)
    {

    }

    protected override MechStates State => MechStates.Dead;
}
