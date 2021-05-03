using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class MovementHandler : MonoBehaviour, IMechComponent
{
    private Mech mech;
    private Vector3 input;
    private Rigidbody _rigidbody;

    private MoveStateMachine stateMachine;

    private MoveNonCombat s_MoveNonCombat;
    private Standing s_standing;



    public float CurrentSpeed { get => _rigidbody.velocity.magnitude; }

    public Movements CurrentMovement
    {
        get => stateMachine.State; 
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
        stateMachine = new MoveStateMachine();

        s_standing = new Standing(mech, stateMachine);
        s_MoveNonCombat = new MoveNonCombat(mech, stateMachine);

        stateMachine.Initialize(s_standing);
    }

    public void Move(Vector3 direction)
    {
        stateMachine.CurrentState.Move(transform, direction, _rigidbody);
    }

    public void ChangeState(Movements state)
    {
        switch (state)
        {
            case Movements.Standing:
                stateMachine.ChangeState(s_standing);
                break;
            case Movements.Moving:
                stateMachine.ChangeState(s_MoveNonCombat);
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
