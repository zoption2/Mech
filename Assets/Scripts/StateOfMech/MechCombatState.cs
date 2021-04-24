using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MechCombatState : MechState
{
    public MechCombatState(Mech character, StateMachine stateMachine) : base(character, stateMachine)
    {

    }

    public override MechStates State => MechStates.Combat;
}
