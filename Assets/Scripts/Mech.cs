using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(MovementHandler))]
[RequireComponent(typeof(MechStateHandler))]
[RequireComponent(typeof(MechAnimationHandler))]
[RequireComponent(typeof(StatsHandler))]

public class Mech : Character
{
    public UnityAction<MechStates> OnStateChange;

    [HideInInspector] public MovementHandler movementHandler;
    [HideInInspector] public MechStateHandler stateHandler;
    [HideInInspector] public MechAnimationHandler animationHandler;
    [HideInInspector] public StatsHandler statsHandler;

    public bool IsReady = false;

    private void Start()
    {
        InitiateComponents();
    }

    public MechStates GetCurrentState()
    {
        return stateHandler.CurrentState;
    }
  
    private void InitiateComponents()
    {
        List<IMechComponent> components = new List<IMechComponent>();
        GetComponents<IMechComponent>(components);
        components.ForEach(s => s.ConnectWithMech(this));
        components.ForEach(s => s.Setup());
        IsReady = true;
    }

}
