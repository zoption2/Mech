using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MechResearchState : MechNonCombatState
{
    public MechResearchState(Mech character, StateMachine stateMachine) : base(character, stateMachine)
    {

    }

    protected override MechStates State => MechStates.Researching;
}
