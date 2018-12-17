using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System;

public abstract class PlayFlickButton : UIFlickButton
{
    MenuPlay windowParent = null;

    protected override void _Start()
    {
        base._Start();
    }

    protected void SetParentFlick(GameItem item, bool add) {
        this.transform.GetComponentInParent<MenuPlay>().SetPlayItem(item, add);
    }

    protected override void Button()
    {
        
    }







}
