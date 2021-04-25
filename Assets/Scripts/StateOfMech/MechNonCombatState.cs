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

    public MechNonCombatState(Mech character, StateMachine stateMachine) : base(character, stateMachine)
    {

    }
}
