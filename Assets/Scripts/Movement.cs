using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public abstract class Movement
{
    public Movement(Stats stats)
    {
        this.stats = stats;
    }

    private Stats stats;


    public abstract void Move(Transform transform, Vector3 direction, Rigidbody rigidbody);

    protected float Accelerate(float currentSpeed)
    {
        if (currentSpeed < stats.MaxSpeed)
        {
            currentSpeed += stats.Acceleration * Time.deltaTime;
            float speedLimit = Mathf.Clamp(currentSpeed, 0, stats.MaxSpeed);
            return speedLimit;
        }
        else
        {
            return currentSpeed;
        }
    }

    protected float SlowDown(float currentSpeed)
    {
        currentSpeed -= stats.SlowDown * Time.deltaTime;
        float speedLimit = Mathf.Clamp(currentSpeed, 0, stats.MaxSpeed);
        return speedLimit;
    }


    protected void DoRotation(Transform transform, Vector3 direction, float rotationSpeed)
    {
        var angle = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(direction), rotationSpeed * Time.deltaTime);
        transform.rotation = angle;
    }

    protected Vector3 GetCurrentDirection(Transform transform)
    {
        Vector3 currentDirection = transform.forward;
        return currentDirection;
    }
}
