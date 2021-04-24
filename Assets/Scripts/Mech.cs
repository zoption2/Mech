using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Movement))]
[RequireComponent(typeof(MechStateHandler))]
[RequireComponent(typeof(MechAnimationHandler))]

public class Mech : Character
{
    public UnityAction<MechStates> OnStateChange;

    [HideInInspector] public Movement movement;
    [HideInInspector] public MechStateHandler stateHandler;
    [HideInInspector] public MechAnimationHandler animationHandler;

    private bool isReady = false;
    public bool IsReady
    {
        get => isReady;
    }
    

    public void InitializeMech()
    {
        InitiateComponents();
        CheckComponents();
        if (!IsReady)
        {
            InitiateComponents();
            Debug.LogWarning("There was components problem, so working of this mech may contain some issues.");
        }
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
    }

    private void CheckComponents()
    {
        string massage = "Mech component {0} was absent!";
        bool areAllComponentsReady = true;

        if (movement == null)
        {
            Debug.LogWarning(massage, movement);
            movement = gameObject.AddComponent<Movement>();
            areAllComponentsReady = false;
        }

        if (stateHandler == null)
        {
            Debug.LogWarning(massage, stateHandler);
            stateHandler = gameObject.AddComponent<MechStateHandler>();
            areAllComponentsReady = false;
        }

        if (animationHandler == null)
        {
            Debug.LogWarning(massage, animationHandler);
            animationHandler = gameObject.AddComponent<MechAnimationHandler>();
            areAllComponentsReady = false;
        }

        isReady = areAllComponentsReady;
    }
}
