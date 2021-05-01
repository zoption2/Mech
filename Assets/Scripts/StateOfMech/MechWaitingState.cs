using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MechWaitingState : MechNonCombatState
{
    public override MechStates State => MechStates.Waiting;

    public MechWaitingState(Mech character, StateMachine stateMachine) : base(character, stateMachine)
    {

    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();
        if (inputs != Vector3.zero)
        {
            character.StateHandler.ChangeState(MechStates.Moving);
        }
    }
}
