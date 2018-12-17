using UnityEngine;
using System.Collections;
using System;

public class MainInfoButton : UIButton
{
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

    protected override void ChangeButton()
    {
        UserMenuRoot.Show<MenuInfo>();
    }




}
