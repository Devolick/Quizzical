using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System;

public class SettingsSoundFlick : UIFlickButton
{

    protected override void _Start()
    {
        base._Start();
        buttonFlicked = PlayerPrefs.GetInt("SettingsSoundFlick") > 0;
        SetEffect(buttonFlicked,1);
        GameInstance.LoadGame.GetComponent<AudioSource>().mute = buttonFlicked;
    }

    public override void Touch(object sender, EventArgs e)
    {
        if (buttonEnable) return;

        TouchEventArgs args = e as TouchEventArgs;
        if (args != null)
        {
            if (args.Gesture == GestureTouch.Tap)
            {
                if (GameInstance.Effects)
                    audioSource.Play();
                base.Touch(sender, e);
            }
        }
    }


    protected override void Button()
    {
        GameInstance.LoadGame.GetComponent<AudioSource>().mute = buttonFlicked;
    }

    void OnDisable() {
        PlayerPrefs.SetInt("SettingsSoundFlick", buttonFlicked ? 1 : 0);
    }


}
