using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class MechAnimationHandler : MonoBehaviour, IMechComponent
{
    private Mech mech;
    private Animator animator;

    private const string animation_idle = "Mech_IDLE";
    private const string animation_Driving = "Mech_Driving";

    private void Awake()
    {
        CheckAnimator();
    }

    public void InitComponent(Mech mech)
    {
        this.mech = mech;
        mech.OnStateChange += DoAnimation;
    }


    private void Statemant(float param)
    {
        animator.SetFloat(animation_idle, param);
    }

    private void DoAnimation(MechStates state)
    {
        switch (state)
        {
            case MechStates.NonCombat:
                break;
            case MechStates.Combat:
                break;
            case MechStates.Waiting:
                break;
            case MechStates.Researching:
                break;
            case MechStates.Stasis:
                break;
            case MechStates.Dead:
                break;
            case MechStates.Trading:
                break;
            default:
                Debug.LogError("Mech states has not containe state: " + state.ToString());
                break;
        }
    }

    private void CheckAnimator()
    {
        TryGetComponent<Animator>(out animator);
        if (!animator)
        {
            Debug.LogError("Can't find Animator component at " + gameObject.name);
        }
    }
}
