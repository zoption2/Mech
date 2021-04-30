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

        Vector3 normaDir = direction.normalized;
        float input = Mathf.Abs(normaDir.magnitude);

        if (input > 0.2f)
        {
            currentSpeed = stats.Speed;
            DoRotation(transform, normaDir, stats.RotationSpeed);
        }


        rigidbody.AddForce(normaDir * currentSpeed, ForceMode.Acceleration);
        Debug.Log("Current speed = " + currentSpeed);
    }
}
