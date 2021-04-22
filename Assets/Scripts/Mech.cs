using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Mech : Character
{
    public UnityAction<MechState> OnStateChange;
    private MechState state;

    public void SetMechState(MechState state)
    {
        this.state = state;
        DoOnStateChange();
    }

    private void DoOnStateChange()
    {
        OnStateChange?.Invoke(state);
    }
}
