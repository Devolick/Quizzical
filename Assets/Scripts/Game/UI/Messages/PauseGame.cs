using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System;

public class PauseGame : UIMessage {

    void ShowAll(bool show) {
        foreach (Transform trs in this.transform)
        {
            if (!(trs.name == "Background"))
            {
                trs.GetComponent<Image>().enabled = show;
            }
        }
    }
    protected override void DefaultHideAll()
    {
        base.DefaultHideAll();
        ShowAll(false);
    }
    protected override void Open()
    {
        base.Open();
        ShowAll(true);
    }
    protected override void Close()
    {
        base.Close();
        ShowAll(false);
    }




}
