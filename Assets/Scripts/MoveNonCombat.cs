using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveNonCombat : Movement
{
    public override void Move(Transform transform, Vector3 direction, Rigidbody rigidbody)
    {
        rigidbody.velocity = direction * Speed;
    }
}
