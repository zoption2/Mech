using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class MovementHandler : MonoBehaviour, IMechComponent
{
    private Mech mech;
    private Vector3 input;
    private Rigidbody _rigidbody;
    private Movement movement;

    public float Speed { get => _rigidbody.velocity.magnitude; }

    public void Awake()
    {
        TryGetComponent<Rigidbody>(out _rigidbody);
        if (!_rigidbody)
        {
            Debug.LogError("Can't find Rigidbody component at " + gameObject.name);
        }
    }

    public void ConnectWithMech(Mech mech)
    {
        this.mech = mech;
        mech.movement = this;
    }

    public void Setup()
    {
        ChangeMovementStyle(MoveStyle.NonCombat);
    }

    public void Move(Vector3 direction)
    {
        movement.Move(transform, direction, _rigidbody);
    }

    public void ChangeMovementStyle(MoveStyle moveStyle)
    {
        switch (moveStyle)
        {
            case MoveStyle.Combat:
                break;
            case MoveStyle.NonCombat:
                movement = new MoveNonCombat();
                break;
            case MoveStyle.Research:
                break;
            default:
                Debug.LogError("There is no move style for " + moveStyle.ToString());
                break;
        }
    }
}
