using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Standing : Movement
{
    public Standing(Mech mech) : base(mech)
    {

    }
    public override Movements State => Movements.Standing;

    public override void Move(Transform transform, Vector3 direction, Rigidbody rigidbody)
    {
        var input = direction.normalized.magnitude;
        if (input > MIN_INPUT_VALUE)
        {
            mech.StateHandler.ChangeState(MechStates.Moving);
        }
    }
}
