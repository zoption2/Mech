using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using UniRx.Triggers;


public class MoveControl : MonoBehaviour
{
    private Vector3 input;
    private Mech mech;
    private float X = 0;
    private float Y = 0;

    private void Start()
    {
        TryGetComponent<Mech>(out mech);
        InitStateObservarable();
        input = new Vector3(X, 0, Y);
    }

    protected virtual void InitMoveObserverable()
    {
        this.FixedUpdateAsObservable()
                   .Where(x => Input.GetAxis("Horizontal") != 0 || Input.GetAxis("Vertical") != 0)
                   .Subscribe(x =>
                   {
                       input = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
                       
                   });
    }

    protected virtual void InitStateObservarable()
    {
        this.UpdateAsObservable().Subscribe(x =>
        {
            input = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
            //X = Input.GetAxis("Horizontal");
            //Y = Input.GetAxis("Vertical");
            mech.movementHandler.Move(input);
        }
        );
    }
}
