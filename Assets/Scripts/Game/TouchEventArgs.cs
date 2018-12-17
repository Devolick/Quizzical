using UnityEngine;
using System.Collections;
using System;

public class TouchEventArgs : EventArgs
{
    RaycastHit2D hit;
    GestureTouch gesture;

    public RaycastHit2D Hit
    {
        get { return hit; }
        set { hit = value; }
    }
    public GestureTouch Gesture
    {
        get { return gesture; }
        set { gesture = value; }
    }

    public bool NullEquals(TouchEventArgs arg)
    {
        if (this.Hit.transform == null && arg.hit.transform == null)
        {
            return true;
        }
        else
        {
            if (this.Hit.transform != null && arg.hit.transform != null)
            {
                if (this.Hit.transform.Equals(arg.hit.transform)) {
                    return true;
                }
                return false;
            }
            return false;
        }
    }

}
