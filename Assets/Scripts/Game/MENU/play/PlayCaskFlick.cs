using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System;

public class PlayCaskFlick : PlayFlickButton
{

    protected override void _Start()
    {
        base._Start();
        SetParentFlick(GameItem.Cask, ButtonEnable);
    }

    public override void Touch(object sender, EventArgs e)
    {
        if (buttonEnable) return;

        TouchEventArgs args = e as TouchEventArgs;
        if (args != null)
        {
            if (args.Gesture == GestureTouch.Tap)
            {
                audioSource.Play();

                base.Touch(sender, e);
            }
        }
    }


    protected override void Button()
    {
        SetParentFlick(GameItem.Cask, ButtonEnable);
    }



}
