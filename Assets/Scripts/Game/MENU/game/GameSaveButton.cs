using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class GameSaveButton : UIButton,IShowLock
{
    public Sprite locked;
    bool buttonLocked = true;

    bool afterFrame = true;

    public override void Touch(object sender, EventArgs e)
    {
        if (buttonLocked) { return; }
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
        UserMenuRoot.Show<MenuSave>();
    }
    public void CheckSave()
    {
        List<SaveList> list;
        if (GameInstance.Save.OpenSave(out list))
        {
            if (list.Count > 0)
            {
                buttonLocked = false;
                imgButton.sprite = released;
            }
            else
            {
                imgButton.sprite = locked;
            }
        }
        else
        {
            imgButton.sprite = locked;
        }
    }
    protected override void _Update()
    {
        base._Update();
        if (afterFrame)
        {
            afterFrame = false;
            CheckSave();
        }
    }

}
