using UnityEngine;
using System.Collections;

public class MenuSave : MenuWindow {

    bool loadSave = false;

    public SavePlayButton PlayButton {
        get;
        set;
    }
    public SaveTable Table {
        get;
        set;
    }

    protected override void _Start()
    {
        base._Start();
    }

    public void PlaySave() {
        GameInstance.SaveIndex = Table.SelectRow.IndexSave;
    }

    public override void Show()
    {
        base.Show();
        if (!loadSave)
        {
            loadSave = true;
            Table.ShowSave();
        }
    }

    protected override void OffWindow()
    {
        base.OffWindow();
        Table.OffSelect();
    }


}
