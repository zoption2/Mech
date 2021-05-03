using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MechCombatState : MechState
{
    public MechCombatState(Mech character, MechStateMachine stateMachine) : base(character, stateMachine)
    {

    }

    public override MechStates State => MechStates.Combat;


    protected override void SwitchAnimation()
    {
        throw new System.NotImplementedException();
    }

    protected override void SwitchControl()
    {
        throw new System.NotImplementedException();
    }

    protected override void SwitchMovement()
    {
        throw new System.NotImplementedException();
    }
}
