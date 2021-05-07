using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlHandler : MonoBehaviour, IMechComponent
{
    private Mech mech;

    public void ConnectWithMech(Mech mech)
    {
        this.mech = mech;
        //mech.InputHandler = this;
    }

    public void Setup()
    {
        
    }

    public enum ControlSets
    {
        NonCombat,
        Combat
    }
}
