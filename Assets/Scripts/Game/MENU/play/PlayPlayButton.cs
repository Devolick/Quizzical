using UnityEngine;
using System.Collections;
using System;

public class PlayPlayButton : UIButton
{
    public Sprite locked;
    bool buttonLocked = true;

    public bool ButtonLocked
    {
        get { return buttonLocked; }
        set
        {
            buttonLocked = value;
            if (!value)
                imgButton.sprite = released;
            else
                imgButton.sprite = locked;
        }
    }

    protected override void _Awake()
    {
        base._Awake();
        this.transform.GetComponentInParent<MenuPlay>().PlayButton = this;
    }

    protected override void _Start()
    {
        base._Start();
        imgButton.sprite = locked;
        //(UserMenuRoot.OpenedWindow as MenuPlay).PlayButton = this;
    }

    public override void Touch(object sender, EventArgs e)
    {
        if (ButtonLocked) { return; }
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
        (UserMenuRoot.OpenedWindow as MenuPlay).PlayGame();

        GameInstance.LoadGame.OpenScene(1);
    }




}
