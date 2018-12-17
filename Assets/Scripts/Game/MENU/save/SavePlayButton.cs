using UnityEngine;
using System.Collections;
using System;

public class SavePlayButton : UIButton
{
    public Sprite locked;
    bool buttonLocked = true;

    public bool ButtonLocked {
        get { return buttonLocked; }
        set {
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
    }

    protected override void _Start()
    {
        base._Start();
        imgButton.sprite = locked;
        this.transform.GetComponentInParent<MenuSave>().PlayButton = this;
        ButtonLocked = true;
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
        (UserMenuRoot.OpenedWindow as MenuSave).PlaySave();

        GameInstance.LoadGame.OpenScene(1);
    }




}
