using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class State
{
    protected Character character;
    protected StateMachine stateMachine;


    public State(Character character, StateMachine stateMachine)
    {
        this.character = character;
        this.stateMachine = stateMachine;
    }

    private void DebugTest()
    {
        Debug.Log("Current State = " + this.GetType().Name);
    }

    public virtual void Enter()
    {
        DebugTest();
    }

    public virtual void LogicUpdate()
    {

    }

    public virtual void PhysicsUpdate()
    {

    }

    public virtual void Exit()
    {

    }

}
