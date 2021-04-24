using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public abstract class Movement
{

    private float maxSpeed = 20;
    private float speed = 10;
    float rotationSpeed = 5;
    float coeficientOfAcceleration = 10;
    float dempingSpeed = 100;

    public float Speed 
    {
        get => speed;
        set => speed = Mathf.Clamp(value, 0, maxSpeed);
    }

    public abstract void Move(Transform transform, Vector3 direction, Rigidbody rigidbody);

    private void Accelerate(bool speedUp)
    {
        if (speedUp)
        {
            Speed += coeficientOfAcceleration * Time.deltaTime;
            Debug.Log("Up - " + Speed);
        }
        else
        {
            Speed -= dempingSpeed * Time.deltaTime;
            Debug.Log("Down - " + Speed);
        }

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
