using UnityEngine;
using System.Collections;

public class MenuMain : MenuWindow {

    protected override void _Start()
    {
        base._Start();
        UserMenuRoot.OpenedWindow = this;
    }






}
