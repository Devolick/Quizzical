using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System;

public class PauseAgain : UIButton
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
        GameState.GameLevelList.RefreshListLevel();
        GameState.Status = GameStatus.Rule;
        UserWindows.Show<PauseGame>(false);
    }











}
