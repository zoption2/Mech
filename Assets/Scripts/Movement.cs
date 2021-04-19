using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(Rigidbody))]
public class Movement : MonoBehaviour
{
    private Vector3 input;
    private Rigidbody _rigidbody;
    float speed = 20;
    float rotationSpeed = 2;
    float coeficientOfAcceleration = 0;

    public void Start()
    {
        TryGetComponent<Rigidbody>(out _rigidbody);
    }

    public void Move(Vector3 direction)
    {
        Vector3 movement;
        DoRotation(direction);
        Vector3 newDirection = GetCurrentDirection();
        float currentSpeed = _rigidbody.velocity.magnitude;
        float differenceAngle = Vector3.Angle(_rigidbody.velocity, direction);
        if (differenceAngle < 90f)
        {
            if (currentSpeed < speed)
            {
                currentSpeed += 10 * Time.deltaTime;
            }
            movement = currentSpeed * newDirection;
        }
        else
        {
            currentSpeed -= 20 * Time.deltaTime;
            movement = currentSpeed * direction;
        }

        
        _rigidbody.velocity = movement;
    }

    private void DoRotation(Vector3 direction)
    {
        var angle = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(direction), rotationSpeed * Time.deltaTime);
        transform.rotation = angle;
    }

    private Vector3 GetCurrentDirection()
    {
        Vector3 currentDirection = transform.forward;
        return currentDirection;
    }


}
