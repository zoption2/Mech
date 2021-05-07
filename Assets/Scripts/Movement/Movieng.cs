using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movieng : Movement
{
    public Movieng(Mech mech) : base(mech)
    {

    }

    public override Movements State => Movements.Moving;


    public override void Move(Transform transform, Vector3 inputVector, Rigidbody rigidbody)
    {
        Vector3 inputNormalized = inputVector.normalized;
        float inputMagnitude = Mathf.Abs(inputNormalized.magnitude);
        float currentSpeed = rigidbody.velocity.magnitude;
        Vector3 moveDirection = rigidbody.velocity.normalized;

        if (inputMagnitude > 0.2f)
        {
            currentSpeed = stats.Speed;
            moveDirection = inputNormalized;
        }

        DoRotation(transform, moveDirection, stats.RotationSpeed);

        rigidbody.AddForce(inputNormalized * currentSpeed, ForceMode.Acceleration);

        if (currentSpeed < stats.Speed/10)
        {
            mech.StateHandler.ChangeState(MechStates.Waiting);
        }
    }
}
