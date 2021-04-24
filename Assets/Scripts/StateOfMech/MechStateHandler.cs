using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MechStateHandler : MonoBehaviour, IMechComponent
{
    private Mech mech;
    private MechStates state;
    private StateMachine stateMachine;
    private MechNonCombatState s_nonCombat;
    private MechCombatState s_combat;
    private MechWaitingState s_waiting;
    private MechStasisState s_stasis;
    private MechResearchState s_research;
    private MechDeadState s_dead;

    public void InitComponent(Mech mech)
    {
        this.mech = mech;

        stateMachine = new MechStateMachine();
        s_nonCombat = new MechNonCombatState(mech, stateMachine);
        s_combat = new MechCombatState(mech, stateMachine);
        s_waiting = new MechWaitingState(mech, stateMachine);
        s_stasis = new MechStasisState(mech, stateMachine);
        s_research = new MechResearchState(mech, stateMachine);
        s_dead = new MechDeadState(mech, stateMachine);
    }

}
