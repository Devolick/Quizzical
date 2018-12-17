using UnityEngine;
using System.Collections;
using System;

public class CellWindow : Base
{
    ItemAdapter itemAdapter = null;

    protected override void _Awake()
    {
        base._Awake();
        itemAdapter = this.transform.Find("Item").GetComponent<ItemAdapter>();
    }

    /// <summary>
    /// SwapItem call this method to adapted item for ui cellwindow
    /// </summary>
    /// <param name="item"></param>
    public void EnableChoice(Item item, bool adapt) {
        if (GameState.Status == GameStatus.Play)
        {
            itemAdapter.ItemAdapt(item, adapt);
        }
    }

    public void SwitchNumber(int number)
    {
        itemAdapter.SwitchNumber(number);
    }

    public void ChoiceItem()
    {
        itemAdapter.ChoiceItem();
    }


}
