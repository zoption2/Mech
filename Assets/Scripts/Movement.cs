using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public abstract class Movement
{
    public Movement(Stats stats)
    {
        this.stats = stats;
    }

    protected Stats stats;


    public abstract void Move(Transform transform, Vector3 direction, Rigidbody rigidbody);

    protected float Accelerate(float currentSpeed)
    {
        float speed = currentSpeed;
        speed += stats.Acceleration * Time.deltaTime;
        return speed;
    }

    protected float SlowDown(float currentSpeed)
    {
        var speed = currentSpeed;
        speed -= stats.SlowDown * Time.deltaTime;
        speed = Mathf.Clamp(speed, 0, stats.MaxSpeed);
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
