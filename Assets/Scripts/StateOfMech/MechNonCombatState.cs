using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MechNonCombatState : State
{
    protected float speed;
    protected float rotationSpeed;

    private Vector3 inputs;

    public MechNonCombatState(Character character, StateMachine stateMachine) : base(character, stateMachine)
    {

    }
}
