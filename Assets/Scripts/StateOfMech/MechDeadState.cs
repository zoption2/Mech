using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MechDeadState : MechState
{
    public MechDeadState(Mech character, MechStateMachine stateMachine) : base(character, stateMachine)
    {

    }

    public override MechStates State => MechStates.Dead;


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
