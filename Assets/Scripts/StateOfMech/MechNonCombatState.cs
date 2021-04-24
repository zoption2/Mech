using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MechNonCombatState : MechState
{
    protected override MechStates State { get => MechStates.NonCombat; }
    protected float speed;
    protected float rotationSpeed;

    private Vector3 inputs;

    private bool isAttack;

    public MechNonCombatState(Mech character, StateMachine stateMachine) : base(character, stateMachine)
    {

    }

}
