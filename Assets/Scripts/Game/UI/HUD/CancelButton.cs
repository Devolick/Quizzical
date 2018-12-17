using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;
using System;

public class CancelButton : UIButton
{
    Image image;
    Collider2D collider2D;
    Image textImage;

    protected override void _Start()
    {
        base._Start();
        image = this.transform.GetComponent<Image>();
        collider2D = this.transform.GetComponent<Collider2D>();
        textImage = this.transform.Find("Text").GetComponent<Image>();

        Show(false);
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

    protected override void ChangeButton()
    {
        switch (GameState.Status)
        {
            case GameStatus.Play:
                {
                    UserInterface.ConfirmButtonUI.ChangeTextByStatus(ConfirmButtonAction.Menu);
                    UserInterface.CellWindowUI.EnableChoice(null, false);
                    break;
                }
            default:
                {
                    UserWindows.Show<PauseGame>(true);
                    break;
                }
        }

        Show(false);
    }

    public void Show(bool show) {
        if (show)
        {
            image.enabled = show;
            collider2D.enabled = show;
            textImage.enabled = show;
        }
        else {
            image.enabled = show;
            collider2D.enabled = show;
            textImage.enabled = show;
        }
    }


}
