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
    private MechMovingState s_moving;
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
        mech.StateHandler = this;
    }

    public void Setup()
    {
        stateMachine = new MechStateMachine();

        s_nonCombat = new MechNonCombatState(mech, stateMachine);
        s_combat = new MechCombatState(mech, stateMachine);
        s_waiting = new MechWaitingState(mech, stateMachine);
        s_moving = new MechMovingState(mech, stateMachine);
        s_stasis = new MechStasisState(mech, stateMachine);
        s_research = new MechResearchState(mech, stateMachine);
        s_dead = new MechDeadState(mech, stateMachine);

        stateMachine.Initialize(s_waiting);
    }

    public void ChangeState(MechStates state)
    {
        switch (state)
        {
            case MechStates.NonCombat:
                stateMachine.ChangeState(s_nonCombat);
                break;
            case MechStates.Moving:
                stateMachine.ChangeState(s_moving);
                break;
            case MechStates.Waiting:
                stateMachine.ChangeState(s_waiting);
                break;
            case MechStates.Combat:
                stateMachine.ChangeState(s_combat);
                break;
            case MechStates.Researching:
                stateMachine.ChangeState(s_research);
                break;
            case MechStates.Stasis:
                stateMachine.ChangeState(s_stasis);
                break;
            case MechStates.Dead:
                stateMachine.ChangeState(s_dead);
                break;
            case MechStates.Trading:
                // not exist now
                break;
            default:
                Debug.LogError("There is no such state as " + state.ToString());
                break;
        }

        DoOnStateChange();
    }


    private void Update()
    {
        LogicUpdate();
    }

    public void LogicUpdate()
    {
        stateMachine.CurrentState.LogicUpdate();
    }

    private void DoOnStateChange()
    {
        mech.OnStateChange?.Invoke(CurrentState);
    }
}
