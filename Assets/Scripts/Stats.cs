using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stats
{
    public Stats()
    {
        MaxSpeed = 30f;
        Acceleration = 300f;
        RotationSpeed = 1.5f;
        SpeedInCombat = 6;
        SlowDown = MaxSpeed;
    }

    public float MaxSpeed;
    public float Acceleration;
    public float SlowDown;
    public float RotationSpeed;
    public float SpeedInCombat;
}
