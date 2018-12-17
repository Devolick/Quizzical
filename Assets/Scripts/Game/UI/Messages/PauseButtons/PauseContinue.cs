using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System;

public class PauseContinue : UIButton
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
        UserWindows.Show<PauseGame>(false);
        
    }


}
