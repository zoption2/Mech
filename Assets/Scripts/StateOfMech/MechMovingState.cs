using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MechMovingState : MechNonCombatState
{
    public override MechStates State => MechStates.Moving;

    public MechMovingState(Mech character, MechStateMachine stateMachine) : base(character, stateMachine)
    {

    }

    protected override void SwitchMovement()
    {
        base.SwitchMovement();
        character.MovementHandler.ChangeState(Movements.Moving);
    }

}
