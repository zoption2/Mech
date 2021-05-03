﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public abstract class MovementState : State
{
    protected new Mech character;
    protected new MoveStateMachine stateMachine;
    protected Stats stats;

    protected const float MIN_INPUT_VALUE = 0.2f;

    public abstract Movements State { get; }

    public MovementState(Mech character, MoveStateMachine stateMachine) : base(character, stateMachine)
    {
        this.character = character;
        this.stateMachine = stateMachine;
        stats = character.statsHandler.Stats;
    }

    public abstract void Move(Transform transform, Vector3 direction, Rigidbody rigidbody);


    protected float Accelerate(float currentSpeed)
    {
        float speed = currentSpeed;
        float coef = 1 - (speed / stats.Speed);

        if (speed < stats.Speed)
        {
           speed += stats.Acceleration * coef * Time.deltaTime;
        }
        return speed;
    }

    protected void DoRotation(Transform transform, Vector3 direction, float rotationSpeed)
    {
        var angle = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(direction), rotationSpeed * Time.deltaTime);
        transform.rotation = angle;
    }

    protected Vector3 GetCurrentDirection(Transform transform)
    {
        return transform.forward;
    }
}
