using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MechResearchState : MechNonCombatState
{
    public MechResearchState(Mech character, MechStateMachine stateMachine) : base(character, stateMachine)
    {

    }

    public override MechStates State => MechStates.Researching;
}
