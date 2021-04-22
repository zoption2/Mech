using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MechStandingState : MechNonCombatState
{
    private bool isAttack;
    public MechStandingState(Character character, StateMachine stateMachine) : base(character, stateMachine)
    {

    }
}
