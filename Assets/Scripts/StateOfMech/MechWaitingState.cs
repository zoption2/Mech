using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MechWaitingState : MechNonCombatState
{
    public override MechStates State => MechStates.Waiting;

    public MechWaitingState(Mech character, MechStateMachine stateMachine) : base(character, stateMachine)
    {

    }
}
