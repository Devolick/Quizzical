using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using System;

public class DataRow : Base, ITouchSender
{
    AudioSource audioSource;
    protected DataTable table;

    public int IndexSave {
        get;
        set;
    } 

    public bool Select {
        get;
        protected set;
    }
    protected override void _Awake()
    {
        base._Awake();
    }
    protected override void _Start()
    {
        base._Start();
        table = transform.parent.GetComponent<DataTable>();
        audioSource = this.transform.GetComponent<AudioSource>();
    }
    public virtual void Touch(object sender, EventArgs e)
    {
        if (Select) { return; }

        Select = true;
        this.GetComponent<Image>().color = new Color(1, 0.79f, 0.41f, this.GetComponent<Image>().color.a); 
        table.SwapRow(this);

        audioSource.Play();
    }
    public virtual void CancelSelect() {
        this.GetComponent<Image>().color = new Color(1, 1, 1, this.GetComponent<Image>().color.a);
        Select = false;
    }
















}
