using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System;

public class ConfirmButton : UIGameButton
{
    public ConfirmButtonAction statusButton = ConfirmButtonAction.None;
    Image textButton;
    CancelButton cancelButton;

    public GameStatus gameStatus;

    protected override void _Start()
    {
        base._Start();
        textButton = this.transform.Find("Text").GetComponent<Image>();
        cancelButton = this.transform.parent.Find("CancelButton").GetComponent<CancelButton>();
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
            case GameStatus.ShowIt: {
                    if (statusButton == ConfirmButtonAction.Play)
                    {
                        ChangeTextByStatus(ConfirmButtonAction.Menu);
                        GameState.Status = GameStatus.HideIt;
                    }
                    else
                    if (statusButton == ConfirmButtonAction.Menu)
                    {
                        UserWindows.Show<PauseGame>(true);
                    }
                    break;
                }
            case GameStatus.Play:
                {
                    if (statusButton == ConfirmButtonAction.Ok)
                    {
                        UserInterface.CellWindowUI.ChoiceItem();
                        ChangeTextByStatus(ConfirmButtonAction.Menu);
                    }
                    else
                    if (statusButton == ConfirmButtonAction.Menu)
                    {
                        UserWindows.Show<PauseGame>(true);
                    }
                    break;
                }
            default: {
                    if (statusButton == ConfirmButtonAction.Menu)
                    {
                        UserWindows.Show<PauseGame>(true);
                    }
                    break;
                }
        }
    }

    public void ChangeTextByStatus(ConfirmButtonAction button) {
        Sprite sp = null;
        switch (button) {
            case ConfirmButtonAction.Menu:
                {
                    SpriteResources.GetSprite(ref sp, "text_menu");
                    cancelButton.Show(false);
                    break;
                }
            case ConfirmButtonAction.Ok:
                {
                    SpriteResources.GetSprite(ref sp, "text_ok");
                    cancelButton.Show(true);
                    break;
                }
            case ConfirmButtonAction.Play:
                {
                    SpriteResources.GetSprite(ref sp, "text_play");
                    cancelButton.Show(true);
                    break;
                }
        }
        if (sp != null) {
            statusButton = button;
            textButton.sprite = sp;
        }
    }

    public void BackConfirm() {
        ChangeTextByStatus(statusButton);
    }

    protected override void ChangeByStatus()
    {
            switch (GameState.Status)
            {
                case GameStatus.Generate:
                    {
                        ChangeTextByStatus(ConfirmButtonAction.Menu);
                        break;
                    }
                case GameStatus.ShowIt:
                    {
                        ChangeTextByStatus(ConfirmButtonAction.Play);
                        break;
                    }
                case GameStatus.Play:
                    {
                        ChangeTextByStatus(ConfirmButtonAction.Menu);
                        break;
                    }
                default:
                    {
                        ChangeTextByStatus(ConfirmButtonAction.Menu);
                        break;
                    }
            }
    }

    protected override void _Update()
    {
        base._Update();
        gameStatus = GameState.Status;
    }
}
