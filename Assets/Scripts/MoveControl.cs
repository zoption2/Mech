using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using UniRx.Triggers;
using UnityEngine.InputSystem;


public class MoveControl : MonoBehaviour
{
    private Vector3 input;
    private Mech mech;
    private Gamepad gamepad;


    private void Start()
    {
        TryGetComponent<Mech>(out mech);
        StartObservable();
        //InitMoveObserverable();
        gamepad = Gamepad.all[0];
    }

    protected virtual void InitMoveObserverable()
    {
        this.FixedUpdateAsObservable()
                   .Where(x => Input.GetAxis("Horizontal") != 0 || Input.GetAxis("Vertical") != 0)
                   .Subscribe(x =>
                   {
                       input = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
                       mech.MovementHandler.Move(input);
                   });
    }

    public void StartObservable()
    {
        StartCoroutine(InitStateObservarable());
    }

    private IEnumerator InitStateObservarable()
    {
        yield return new WaitUntil(() => mech.IsReady);

        this.FixedUpdateAsObservable().Subscribe(x =>
        {
            //input = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
            input = new Vector3(gamepad.leftStick.ReadValue().x, 0, gamepad.leftStick.ReadValue().y);
            mech.MovementHandler.Move(input);
        }
        );

        this.FixedUpdateAsObservable()
            .Where(x => gamepad.buttonSouth.isPressed)
            .Subscribe(x =>
            {
                mech.targetHandler.GetClosestTarget();
            }
            );

        this.FixedUpdateAsObservable()
            .Where(x => gamepad.buttonEast.isPressed)
            .Subscribe(x =>
            {
                mech.holder.Deactivate("Selection");
            }
            );
    }
}
