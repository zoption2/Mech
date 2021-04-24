using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MechStasisState : MechState
{
    public MechStasisState(Mech character, StateMachine stateMachine) : base(character, stateMachine)
    {

    }

    public override MechStates State => MechStates.Stasis;
}
