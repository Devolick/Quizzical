using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameState : Base {

    static GameState instance = null;

    GameStatus gameStatus = GameStatus.None;
    GameStatus saveStatus = GameStatus.None;
    GameStatus gameStatusChange = GameStatus.None;
    GameStatusShowOnce showStatusOnce = GameStatusShowOnce.Lock;

    SaveList saveList;

    public static bool StatusChanged {
        get;
        private set;
    }
    public static SaveList GameLevelList {
        get { return instance.saveList; }
        set { instance.saveList = value; }
    }
    protected override void _Awake()
    {
        base._Awake();
        instance = this;
    }
    public static GameStatus Status {
        get {
            return instance.gameStatus;
        }
        set {
            instance.gameStatus = value;
            if (instance.gameStatusChange != instance.gameStatus)
            {
                instance.showStatusOnce = GameStatusShowOnce.Show;
                instance.gameStatusChange = instance.gameStatus;
            }
        }
    }
    void HasStatusChanged() {
        if (showStatusOnce == GameStatusShowOnce.Show)
        {
            showStatusOnce = GameStatusShowOnce.Once;
            StatusChanged = true;
        }
        else {
            showStatusOnce = GameStatusShowOnce.Lock;
            StatusChanged = false;
        }
    }
    protected override void _Update()
    {
        base._Update();
        HasStatusChanged();
    }


}
