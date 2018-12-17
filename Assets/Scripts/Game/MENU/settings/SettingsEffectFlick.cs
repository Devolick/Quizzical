using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System;

public class SettingsEffectFlick : UIFlickButton
{

    protected override void _Start()
    {
        base._Start();
        buttonFlicked = PlayerPrefs.GetInt("SettingsEffectFlick") > 0;
        SetEffect(buttonFlicked, 1);
        GameInstance.Effects = !buttonFlicked;
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
        GameInstance.Effects = !buttonFlicked;
    }

    void OnDisable()
    {
        PlayerPrefs.SetInt("SettingsEffectFlick", buttonFlicked ? 1 : 0);
    }

}
