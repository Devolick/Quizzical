using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System;

public class SaveRow : DataRow {

    public Text LevelText
    {
        get;
        protected set;
    }
    public Text ItemsText
    {
        get;
        protected set;
    }

    protected override void _Awake()
    {
        base._Awake();
        LevelText = this.transform.Find("Level").GetComponent<Text>();
        ItemsText = this.transform.Find("Items").GetComponent<Text>();
    }
    protected override void _Start()
    {
        base._Start();
        table = transform.parent.GetComponent<DataTable>();
    }

    public override void Touch(object sender, EventArgs e)
    {
        TouchEventArgs args = e as TouchEventArgs;
        if (args != null)
        {
            if (args.Gesture == GestureTouch.Move ||
                args.Gesture == GestureTouch.Tap)
            {
                base.Touch(sender, e);
            }
        }
    }



















}
