using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Standing : MovementState
{
    public Standing(Mech character, MoveStateMachine stateMachine) : base(character, stateMachine)
    {

    }

    public override Movements State => Movements.Standing;

    public override void Move(Transform transform, Vector3 direction, Rigidbody rigidbody)
    {
        var input = direction.normalized.magnitude;
        if (input > MIN_INPUT_VALUE)
        {
            character.StateHandler.ChangeState(MechStates.Moving);
        }
    }
}
