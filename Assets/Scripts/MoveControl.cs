using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using UniRx.Triggers;


public class MoveControl : MonoBehaviour
{
    private Vector3 input;
    private Movement movement;

    private void Start()
    {
        TryGetComponent<Movement>(out movement);
        InitMoveObserverable();
    }

    protected virtual void InitMoveObserverable()
    {
        this.FixedUpdateAsObservable()
                   .Where(x => Input.GetAxis("Horizontal") != 0 || Input.GetAxis("Vertical") != 0)
                   .Subscribe(x =>
                   {
                       input = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
                       movement.Move(input);
                   });
    }
}
