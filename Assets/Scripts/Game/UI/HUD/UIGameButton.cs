using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System;

public abstract class UIGameButton: UIButton
{

    protected override void _Start()
    {
        base._Start();
        
    }

    protected abstract void ChangeByStatus();

    protected override void _Update()
    {
        base._Update();
        if (GameState.StatusChanged)
        {
            ChangeByStatus();
        }
    }


}
