using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(Rigidbody))]
public class Movement : MonoBehaviour, IMechComponent
{
    private Mech mech;
    private Vector3 input;
    private Rigidbody _rigidbody;
    private float maxSpeed = 20;
    private float speed = 0;
    float rotationSpeed = 5;
    float coeficientOfAcceleration = 10;
    float dempingSpeed = 100;

    public float Speed 
    {
        get => speed;
        set => speed = Mathf.Clamp(value, 0, maxSpeed);
    }

    public void Awake()
    {
        TryGetComponent<Rigidbody>(out _rigidbody);
        if (!_rigidbody)
        {
            Debug.LogError("Can't find Rigidbody component at " + gameObject.name);
        }
    }

    public void SetMech(Mech mech)
    {
        this.mech = mech;
    }

    public void Setup()
    {

    }

    public void Move(Vector3 direction)
    {
        float pressPower = direction.normalized.magnitude;

        Accelerate(pressPower > 0.2f);
        Vector3 moveDirection;
        var coefficient = Speed / maxSpeed;
        Debug.Log(coefficient);
        if (coefficient < 0.7f)
        {
            moveDirection = direction;
        }
        else 
        {
            moveDirection = GetCurrentDirection();
        }

        DoRotation(direction, 1 - coefficient);
        _rigidbody.velocity = Speed * moveDirection;
    }

    private void Accelerate(bool speedUp)
    {
        if (speedUp)
        {
            speed += coeficientOfAcceleration * Time.deltaTime;
        }
        else
        {
            speed -= dempingSpeed * Time.deltaTime;
        }
    }

    private void DoRotation(Vector3 direction, float rotationCoeficient)
    {
        var angle = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(direction), rotationCoeficient * rotationSpeed * Time.deltaTime);
        transform.rotation = angle;
    }

    private Vector3 GetCurrentDirection()
    {
        Vector3 currentDirection = transform.forward;
        return currentDirection;
    }


}
