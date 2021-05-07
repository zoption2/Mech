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

    private Movieng s_Moving;
    private Standing s_standing;


    public float CurrentSpeed { get => _rigidbody.velocity.magnitude; }

    public Movements CurrentMovement
    {
        get => movement.State; 
    }

    private void Awake()
    {
        GetRigidbody();
    }


    public void ConnectWithMech(Mech mech)
    {
        this.mech = mech;
        mech.MovementHandler = this;
    }

    public void Setup()
    {
        s_standing = new Standing(mech);
        s_Moving = new Movieng(mech);

        movement = s_standing;
    }

    public void Move(Vector3 direction)
    {
        movement.Move(transform, direction, _rigidbody);
    }

    public void ChangeState(Movements state)
    {
        switch (state)
        {
            case Movements.Standing:
                movement = s_standing;
                break;
            case Movements.Moving:
                movement = s_Moving;
                break;
            case Movements.BattleMoving:
                break;
            default:
                throw new System.NotImplementedException();
                break;
        }
    }

    private void GetRigidbody()
    {
        TryGetComponent<Rigidbody>(out _rigidbody);
        if (!_rigidbody)
        {
            Debug.LogError("Can't find Rigidbody component at " + gameObject.name);
        }
    }
}
