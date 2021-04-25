using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatsHandler : MonoBehaviour, IMechComponent
{
    private Mech mech;
    private Stats stats;

    public Stats Stats { get => stats; }

    private void Start()
    {
        SetStats(new Stats());
    }
    public void ConnectWithMech(Mech mech)
    {
        this.mech = mech;
        mech.statsHandler = this;
    }

    public void Setup()
    {
        
    }

    public void SetStats(Stats stats)
    {
        this.stats = stats;
    }
}
