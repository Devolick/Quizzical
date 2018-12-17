using UnityEngine;
using System.Collections;
using System;

public class GemItem : Item
{

    protected override void _Awake()
    {
        base._Awake();
        myName = GameItem.Gem;
        filterNumberMax = 4;
        number = RandNumber();
    }

    public override void Touch(object sender, EventArgs e)
    {
        TouchEventArgs args = e as TouchEventArgs;
        if (args != null)
        {
            if (args.Gesture == GestureTouch.Tap)
            {
                base.Touch(sender, e);
            }
        }
    }


}
