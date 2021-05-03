using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class MechState : State
{
    protected new Mech character;
    protected new MechStateMachine stateMachine;

    public abstract MechStates State { get; }

    public MechState(Mech character, MechStateMachine stateMachine) : base(character, stateMachine)
    {
        this.character = character;
        this.stateMachine = stateMachine;
    }

    public override void Enter()
    {
        base.Enter();
        SwitchControl();
        SwitchAnimation();
        SwitchMovement();
    }

    protected abstract void SwitchControl();
    protected abstract void SwitchAnimation();
    protected abstract void SwitchMovement();

}
