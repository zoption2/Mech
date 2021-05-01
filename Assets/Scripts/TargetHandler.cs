using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TargetHandler : MonoBehaviour, IMechComponent
{
    public UnityAction OnTargetChange;

    private Mech mech;

    private GameObject thisShip;
    private List<ITargetable> observableObjects;
    private GameObject currentTarget;

    private const int DETECTION_LAYER = 1 << 8;


    public void ConnectWithMech(Mech mech)
    {
        this.mech = mech;
        mech.targetHandler = this;
    }

    public void Setup()
    {
        SetRadiusOfVision(mech.statsHandler.Stats.RadiusOfVision);
    }


    public GameObject GetCurrentTarget()
    {
        return currentTarget;
    }

    public void ChangeCurrentTarget()
    {
        FindTargets();

        var countOfTargets = observableObjects.Count;
        var randomValue = Random.Range(0, countOfTargets - 1);
        var newTarget = observableObjects[randomValue];
        SetCurrentTarget(newTarget);
    }

    public void GetClosestTarget()
    {
        FindTargets();

        if (observableObjects.Count <= 0)
        {
            return;
        }

        ITargetable closest = null;
        float distance = Mathf.Infinity;
        Vector3 myPosition = transform.position;

        for (int i = 0; i < observableObjects.Count; i++)
        {
            var target = observableObjects[i];
            var targetPosition = target.GetTarget().transform.position;
            float difference = Vector3.Distance(targetPosition, myPosition);
            if (difference < distance)
            {
                closest = target;
            }
        }

        SetCurrentTarget(closest);

        Debug.Log("ENEMY - " + GetCurrentTarget().name);
    }

    public void SetRadiusOfVision(float radius)
    {
        mech.Stats.RadiusOfVision = radius;
    }

    public void FindTargets()
    {
        observableObjects = new List<ITargetable>();

        Collider[] targets = new Collider[10];
        int finded = Physics.OverlapSphereNonAlloc(transform.position, mech.Stats.RadiusOfVision, targets, DETECTION_LAYER);

        for (int i = 0; i < finded; i++)
        {
            var target = targets[i].gameObject.GetComponentInParent<ITargetable>();
            if (target != null && target.GetTarget() != this.gameObject) //&& target.GetTeam() != stats.Team)
            {
                observableObjects.Add(target);
            }
        }
    }

    private void SetCurrentTarget(ITargetable target)
    {
        currentTarget = target.GetTarget();
        target.InformAboutTargeting();

        DoTargetChange();
    }

    private void DoTargetChange()
    {
        OnTargetChange?.Invoke();
    }

}



