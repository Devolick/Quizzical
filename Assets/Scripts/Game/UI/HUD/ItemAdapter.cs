using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System;

public class ItemAdapter:Base
{
    Item item = null;
    Image render = null;
    int number = 1;

    public Item AdaptedItem {
        get { return item; }
    }

    protected override void _Start()
    {
        base._Start();
        render = this.transform.GetComponent<Image>();
    }

    /// <summary>
    /// Method adapt item for work with their
    /// </summary>
    public void ItemAdapt(Item item,bool adapt) {

        if (adapt)
        {

            this.item = item;
            this.number = this.item.RandNumber();
            Show(true);
            UserInterface.RainbowButtonUI.EnableSwap = true;
            UserInterface.ConfirmButtonUI.ChangeTextByStatus(ConfirmButtonAction.Ok);
        }
        else {
            if (this.item != null)
            {
                Show(false);
                this.item.UnSelectItem();
                this.item = null;
                UserInterface.RainbowButtonUI.EnableSwap = false;
            }
        }
    }

    public void Show(bool show) {
        Sprite sp = null;
        if (!show)
        {
            if (SpriteResources.GetSprite(ref sp, "ItemQuestion"))
            {
                render.sprite = sp;
            }
        }
        else {
            if (SpriteResources.GetSprite(ref sp, item.MyName.ToString() + this.number))
            {
                render.sprite = sp;
            }
        }
    }

    public void SwitchNumber(int number) {
        this.number = item.FilterNumber(this.number + number);
        Show(true);
    }

    public void ChoiceItem() {
        if (item == null) return;

        UserInterface.RainbowButtonUI.EnableSwap = false;
        item.Found(number);
        Show(false);
        item = null;
    }



}
