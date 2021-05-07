using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Controls
{
    protected Mech mech;

    public Controls(Mech mech)
    {
        this.mech = mech;
    }

    public abstract void ControlLeftStick(Vector2 inputs);
    public abstract void ControlRightStick(Vector2 inputs);

}
