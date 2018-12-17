using UnityEngine;
using System.Collections;
using System;

public class DiceItem : Item
{

    protected override void _Awake()
    {
        base._Awake();
        myName = GameItem.Dice;
        filterNumberMax = 6;
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
