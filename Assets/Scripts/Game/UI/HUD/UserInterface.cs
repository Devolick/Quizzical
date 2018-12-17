using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System;

public class UserInterface : Base {
    static UserInterface instance = null;

    CellWindow cellWindow = null;
    ConfirmButton confirmButton = null;
    RainbowButton rainbowButton = null;

    public static CellWindow CellWindowUI {
        get { return instance.cellWindow; }
    }
    public static ConfirmButton ConfirmButtonUI {
        get { return instance.confirmButton; }
    }
    public static RainbowButton RainbowButtonUI {
        get { return instance.rainbowButton; }
    }

    protected override void _Awake()
    {
        base._Awake();
        instance = this;
        FillLayer = false;
    }


    protected override void _Start()
    {
        base._Start();
        Canvas canvas = this.transform.GetComponent<Canvas>();
        canvas.renderMode = RenderMode.ScreenSpaceCamera;
        canvas.worldCamera = GameObject.Find("Camera").GetComponent<Camera>();

        cellWindow = this.transform.transform.Find("CellWindow").GetComponent<CellWindow>();
        confirmButton = this.transform.transform.Find("ConfirmButton").GetComponent<ConfirmButton>();
        rainbowButton = this.transform.transform.Find("RainbowButton").GetComponent<RainbowButton>();
    }

}
