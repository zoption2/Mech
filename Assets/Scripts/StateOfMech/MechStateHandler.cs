using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MechStateHandler : MonoBehaviour, IMechComponent
{

    private Mech mech;

    private MechStateMachine stateMachine;
    private MechNonCombatState s_nonCombat;
    private MechCombatState s_combat;
    private MechWaitingState s_waiting;
    private MechStasisState s_stasis;
    private MechResearchState s_research;
    private MechDeadState s_dead;

    public MechStates CurrentState 
    {
        get => stateMachine.State; 
    }

    public void ConnectWithMech(Mech mech)
    {
        this.mech = mech;
        mech.stateHandler = this;
    }

    public void Setup()
    {
        stateMachine = new MechStateMachine();

        s_nonCombat = new MechNonCombatState(mech, stateMachine);
        s_combat = new MechCombatState(mech, stateMachine);
        s_waiting = new MechWaitingState(mech, stateMachine);
        s_stasis = new MechStasisState(mech, stateMachine);
        s_research = new MechResearchState(mech, stateMachine);
        s_dead = new MechDeadState(mech, stateMachine);

        stateMachine.Initialize(s_waiting);
    }

    private void DoOnStateChange()
    {
        mech.OnStateChange?.Invoke(CurrentState);
    }
}
