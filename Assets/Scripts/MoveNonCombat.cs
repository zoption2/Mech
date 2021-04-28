using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveNonCombat : Movement
{
    public MoveNonCombat(Stats stats) : base(stats)
    {

    }

    public override void Move(Transform transform, Vector3 direction, Rigidbody rigidbody)
    {
        float currentSpeed = rigidbody.velocity.magnitude;
        float input = Mathf.Abs(direction.normalized.magnitude);

        if (input > 0.2f)
        {
            float speed = Accelerate(currentSpeed);
            currentSpeed = Mathf.Clamp(speed, 0, stats.MaxSpeed);
            DoRotation(transform, direction, stats.RotationSpeed);
        }


        rigidbody.AddForce(direction * currentSpeed, ForceMode.Acceleration);
        Debug.Log("Current speed = " + currentSpeed);
    }
}
