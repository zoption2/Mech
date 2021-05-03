using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MechNonCombatState : MechState
{
    public override MechStates State { get => MechStates.NonCombat; }
    protected float speed;
    protected float rotationSpeed;

    protected Vector3 inputs;

    private bool isAttack;
    private bool isMoving;

    public MechNonCombatState(Mech character, MechStateMachine stateMachine) : base(character, stateMachine)
    {

    }

    protected override void SwitchControl()
    {
        throw new System.NotImplementedException();
    }

    protected override void SwitchAnimation()
    {
        throw new System.NotImplementedException();
    }

    protected override void SwitchMovement()
    {
        throw new System.NotImplementedException();
    }
}
