using UnityEngine;
using System.Collections;
using System;

public class GameRule : Base {
    Table table;
    int repeatCycle = 1;
    int repeatLevel = 0;

    GameAnswer gameAnswer = GameAnswer.None;
    Delay delayMethod;

    [SerializeField]
    int adsRepeatAfterAnswers = 50;
    int adsCountRepeats = 0;

    protected override void _Awake()
    {
        base._Awake();
        delayMethod = new Delay();
        adsCountRepeats = adsRepeatAfterAnswers;
    }
    protected override void _Start()
    {
        base._Start();
        table = this.transform.GetComponent<Table>();
    }
    void ShowAds() {
        if (adsCountRepeats < 1) {
            adsCountRepeats = adsRepeatAfterAnswers;
            //AdManager.Ad.ShowAd(true);
        }
    }
    void EnableRule()
    {
        if (GameState.StatusChanged)
        {
            if (GameState.Status == GameStatus.Rule)
            {
                ShowAds();

                repeatCycle = 1;
                repeatLevel = 0;

                GameState.Status = GameStatus.Generate;
            } 
        }
    }
    void RuleAlgorithm() {
        if (GameState.Status == GameStatus.Play)
        {
            if (CheckGame())
            {
                NextLevel();
            }
            else
            {
                RepeatLevel();
            }
        }
    }
    bool CheckGame() {
        int level = GameState.GameLevelList.Level;
        int itemsInGame = level * (2+ (int)(level / 5));
        if (itemsInGame <= GameState.GameLevelList.LevelItemList().Items.Count) {
            return true;
        }
        return false;
    }


    void RepeatLevel()
    { 
        int level = GameState.GameLevelList.Level;
        int repeatsItems = level * repeatCycle;
        if (repeatsItems <= GameState.GameLevelList.LevelItemList().Items.Count)
        {
            ++repeatCycle;
            gameAnswer = GameAnswer.Repeat;
            ShowAnswers();
        }
    }
    void NextLevel() {
        int foundItem = 0;
        for (int i = 0; i < GameState.GameLevelList.LevelItemList().Items.Count; ++i) {
            if (GameState.GameLevelList.LevelItemList().Items[i].Value) {
                ++foundItem;
            }
        }
        if (Table.MAX_ITEMS <= GameState.GameLevelList.Level)
        {
            ShowAnswers();
            gameAnswer = GameAnswer.Win;
            --adsCountRepeats;
        }
        else
        {
            if (foundItem > (GameState.GameLevelList.LevelItemList().Items.Count - foundItem))
            {
                ShowAnswers();
                gameAnswer = GameAnswer.Next;
                --adsCountRepeats;
            }
            else
            {
                ShowAnswers();
                gameAnswer = GameAnswer.Drop;
                --adsCountRepeats;
            }
        }
    }
    void ShowAnswers() {
        GameState.Status = GameStatus.Answers;
        delayMethod.RegisterOnce(PlayNext, 2, true);
    }
    void PlayNext() {
        switch (gameAnswer) {
            case GameAnswer.Repeat:
                {
                    GameState.Status = GameStatus.Generate;
                    break;
                }
            case GameAnswer.Win:
                {
                    GameInstance.Save.Save(GameState.GameLevelList);
                    UserWindows.Show<WinGame>(true);
                    break;
                }
            case GameAnswer.Next:
                {
                    GameState.GameLevelList.LevelItemListNew();
                    GameInstance.Save.Save(GameState.GameLevelList);
                    UserWindows.Show<NextLevel>(true);
                    break;
                }
            case GameAnswer.Drop:
                {
                    GameState.GameLevelList.DropItemListLevel();
                    GameInstance.Save.Save(GameState.GameLevelList);
                    UserWindows.Show<DropLevel>(true);
                    break;
                }
        }
    }
    protected override void _Update()
    {
        base._Update();
        EnableRule();
        RuleAlgorithm();

        delayMethod.PlayDelay(Time.fixedDeltaTime);
    }




}
