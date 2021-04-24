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

    private void DoAnimation(MechState state)
    {
        switch (state)
        {
            case MechState.Standing:
                animator.Play(animation_idle);
                break;
            case MechState.Driving:
                animator.Play(animation_Driving);
                break;
            case MechState.Fighting:
                break;
            case MechState.Dying:
                break;
            case MechState.Disabling:
                break;
            case MechState.Trading:
                break;
            default:
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
