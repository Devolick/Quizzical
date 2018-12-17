using UnityEngine;
using System.Collections;
using System;

public abstract class UIObject : Base, ITouchSender
{

    protected override void _Awake()
    {
        base._Awake();

    }
    public abstract void Touch(object sender, EventArgs e);









}
