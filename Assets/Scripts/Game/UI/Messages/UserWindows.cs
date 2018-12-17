using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System;

public class UserWindows : Base
{
    static UserWindows instance = null;

    public bool LockViewportTouch
    {
        get
        {
            return true;
        }
    }

    protected override void _Awake()
    {
        base._Awake();
        instance = this;
        FillLayer = false;
    }

    public static void Show<T>(bool show) where T : UIMessage
    {
        instance.transform.GetComponentInChildren<T>().Show(show);
    }




}
