using UnityEngine;
using System.Collections;
using System;

public class SwapItem : Base
{
    static SwapItem instance;
    private Item selectItem = null;

    /// <summary>
    /// To take select item
    /// </summary>
    public static Item Select {
        get { return instance.selectItem; }
        set { instance.selectItem = value; }
    }

    protected override void _Awake()
    {
        base._Awake();
        instance = this;
    }





}
