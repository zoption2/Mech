using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(MovementHandler))]
[RequireComponent(typeof(MechStateHandler))]
[RequireComponent(typeof(MechAnimationHandler))]
[RequireComponent(typeof(StatsHandler))]
[RequireComponent(typeof(TargetHandler))]

public class Mech : Character
{
    public UnityAction<MechStates> OnStateChange;

    [HideInInspector] public MovementHandler MovementHandler;
    [HideInInspector] public MechStateHandler StateHandler;
    [HideInInspector] public MechAnimationHandler animationHandler;
    [HideInInspector] public StatsHandler statsHandler;
    [HideInInspector] public TargetHandler targetHandler;

    [HideInInspector] public PersonalHolder holder;
    
    public bool IsReady = false;

    public Stats Stats 
    { 
        get => statsHandler.Stats; 
    }

    private void Start()
    {
        InitiateComponents();
    }

    public MechStates GetCurrentState()
    {
        return StateHandler.CurrentState;
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
