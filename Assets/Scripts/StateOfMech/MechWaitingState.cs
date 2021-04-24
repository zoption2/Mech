using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MechWaitingState : MechNonCombatState
{
    public MechWaitingState(Mech character, StateMachine stateMachine) : base(character, stateMachine)
    {

    }

    protected override MechStates State => MechStates.Waiting;
}
