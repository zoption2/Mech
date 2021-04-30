using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stats
{
    public Stats()
    {
        Speed = 30f;
        Acceleration = 1000f;
        RotationSpeed = 1.5f;
        SlowDown = Speed;
        engineGrade = 1;

        SpeedInCombat = 6;
    }

    public float Speed;
    public float Acceleration;
    public int engineGrade;
    public float SlowDown;
    public float RotationSpeed;

    public float SpeedInCombat;
}
