using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System;

public class ScoreRow : DataRow {

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

    public ScoreExtraRow Extra1
    {
        get;
        protected set;
    }

    public ScoreExtraRow Extra2
    {
        get;
        protected set;
    }

    protected override void _Awake()
    {
        base._Awake();
        LevelText = this.transform.Find("Level").GetComponent<Text>();
        ItemsText = this.transform.Find("Items").GetComponent<Text>();
        Extra1 = transform.Find("ExtraRow1").GetComponent<ScoreExtraRow>();
        Extra1.gameObject.SetActive(false);
        Extra2 = transform.Find("ExtraRow2").GetComponent<ScoreExtraRow>();
        Extra2.gameObject.SetActive(false);
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
                Extra1.gameObject.SetActive(true);
                Extra2.gameObject.SetActive(true);
            }
        }
    }
    public override void CancelSelect()
    {
        base.CancelSelect();
        Extra1.gameObject.SetActive(false);
        Extra2.gameObject.SetActive(false);
    }























}
