using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class PersonalHolder : MonoBehaviour, IMechComponent
{
    

    private Mech mech;

    public void ConnectWithMech(Mech mech)
    {
        this.mech = mech;
        mech.holder = this;
    }

    public void Setup()
    {
        
    }
}
