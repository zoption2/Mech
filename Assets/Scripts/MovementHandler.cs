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
        mech.movementHandler = this;
    }

    public void Setup()
    {
        movement = new MoveNonCombat(mech.statsHandler.Stats);
        mech.OnStateChange += ChangeMovementStyle;
    }

    public void Move(Vector3 direction)
    {
        movement.Move(transform, direction, _rigidbody);
        Debug.Log("Current movement = " + movement.ToString());
    }

    public void ChangeMovementStyle(MechStates state)
    {
        switch (state)
        {
            case MechStates.NonCombat:
                movement = new MoveNonCombat(mech.statsHandler.Stats);
                break;
            case MechStates.Combat:
                break;
            case MechStates.Dead:
                break;
            default:
                Debug.Log("Another state is a problem for me" + movement.ToString());
                break;
        }
    }

    private void OnDestroy()
    {
        mech.OnStateChange -= ChangeMovementStyle;
    }
}
