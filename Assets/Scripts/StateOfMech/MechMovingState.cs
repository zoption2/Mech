using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MechMovingState : MechNonCombatState
{
    public override MechStates State => MechStates.Moving;

    public MechMovingState(Mech character, StateMachine stateMachine) : base(character, stateMachine)
    {

    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();
        if (inputs == Vector3.zero)
        {
            character.stateHandler.ChangeState(MechStates.Waiting);
        }
    }
}
