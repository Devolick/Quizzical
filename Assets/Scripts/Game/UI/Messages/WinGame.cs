using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using System;

public class WinGame : UIMessage
{



    protected override void Open()
    {
        base.Open();

        delay.RegisterOnce(WaitSecond, 5, true);
    }

    void WaitSecond()
    {
        GameInstance.LoadGame.OpenScene(0);
    }

}
