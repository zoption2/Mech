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
        Debug.Log("Current inputs = " + input);
        if (input < 0.2f)
        {
            currentSpeed = SlowDown(currentSpeed);
        }
        else
        {
            currentSpeed = Accelerate(currentSpeed);
        }

        rigidbody.velocity = direction * currentSpeed;
        Debug.Log("Current speed = " + currentSpeed);
    }
}
