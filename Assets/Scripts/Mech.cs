using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Mech : Character
{
    public UnityAction<MechStates> OnStateChange;

    public Movement movement;
    public MechStateHandler stateHandler;
    public MechAnimationHandler animationHandler;
    

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
        components.ForEach(s => s.InitComponent(this));
    }

}
