using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SaveTable : DataTable {

    bool saveReady = false;

    protected override void _Awake()
    {
        base._Awake();
    }

    protected override void _Start()
    {
        base._Start();
        this.transform.GetComponentInParent<MenuSave>().Table = this;
    }
    public void ShowSave()
    {
        List<SaveList> list;
        if (GameInstance.Save.OpenSave(out list))
        {
            for (int i = 0; i < list.Count; ++i)
            {
                SaveRow row = AddRow("SaveRow",i) as SaveRow;
                row.IndexSave = i;
                row.LevelText.text = "  LEVEL " + list[i].Level;
                string items = "";
                foreach (GameItem it in list[i].PlayItems)
                {
                    items += " " + it.ToString();
                }
                row.ItemsText.text = "  ITEMS " + items;
            }
        }
    }

    public override void SwapRow(DataRow row)
    {
        base.SwapRow(row);
        (UserMenuRoot.OpenedWindow as MenuSave).PlayButton.ButtonLocked = false;
    }

    public void OffSelect()
    {
        if (SelectRow != null)
        {
            SelectRow.CancelSelect();
            (UserMenuRoot.OpenedWindow as MenuSave).PlayButton.ButtonLocked = true;
        }
    }


}
