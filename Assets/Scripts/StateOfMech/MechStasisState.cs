using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MechStasisState : MechState
{
    public override MechStates State => MechStates.Stasis;

    public MechStasisState(Mech character, MechStateMachine stateMachine) : base(character, stateMachine)
    {

    }



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
