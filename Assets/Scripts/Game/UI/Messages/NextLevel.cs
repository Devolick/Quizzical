using UnityEngine;
using System.Collections;
using System;

public class NextLevel : UIMessage
{

    protected override void Open()
    {
        base.Open();
        GameState.Status = GameStatus.Rule;
        delay.RegisterOnce(WaitSecond, 3, true);
    }

    void WaitSecond()
    {
        Show(false);
    }






}
