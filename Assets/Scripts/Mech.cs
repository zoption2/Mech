using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Mech : Character
{
    public UnityAction<MechState> OnStateChange;
    private MechState state;

    private Movement movement;
    private MechStateHandler stateHandler;
    private MechAnimationHandler animationHandler;

    private void Start()
    {
        InitiateComponents();
    }

    public void SetMechState(MechState state)
    {
        this.state = state;
        DoOnStateChange();
    }

    private void InitiateComponents()
    {
        List<IMechComponent> components = new List<IMechComponent>();
        GetComponents<IMechComponent>(components);
        components.ForEach(s => s.InitComponent(this));
    }

    private void DoOnStateChange()
    {
        OnStateChange?.Invoke(state);
    }
}
