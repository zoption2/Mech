using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interaction : MonoBehaviour, IMechComponent, ITargetable
{
    private Mech mech;

    public void ConnectWithMech(Mech mech)
    {
        this.mech = mech;
    }

    public void Setup()
    {
        
    }

    public GameObject GetTarget()
    {
        return gameObject;
    }

    public void InformAboutTargeting()
    {
        mech.holder.Activate(PersonalHolder.Items.SelectingCircle);
    }
}
