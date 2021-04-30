using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using UniRx.Triggers;


public class MoveControl : MonoBehaviour
{
    private Vector3 input;
    private Mech mech;


    private void Start()
    {
        TryGetComponent<Mech>(out mech);
        StartObservable();
        //InitMoveObserverable();
    }

    protected virtual void InitMoveObserverable()
    {
        this.FixedUpdateAsObservable()
                   .Where(x => Input.GetAxis("Horizontal") != 0 || Input.GetAxis("Vertical") != 0)
                   .Subscribe(x =>
                   {
                       input = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
                       mech.movementHandler.Move(input);
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

            input = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
            mech.movementHandler.Move(input);
        }
        );
    }
}
