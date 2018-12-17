using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MenuPlay : MenuWindow {

    List<GameItem> playItems = null;
    public PlayPlayButton PlayButton {
        get;
        set;
    }

    protected override void _Awake()
    {
        base._Awake();
        playItems = new List<GameItem>();
    }

    protected override void _Start()
    {
        base._Start();
    }

    public void SetPlayItem(GameItem item, bool add) {
        if (add)
        {
            if (!playItems.Contains(item))
                playItems.Add(item);
        }
        else
        {
            if (playItems.Contains(item))
                playItems.RemoveAt(playItems.IndexOf(item));
        }
        if (playItems.Count < 1)
        {
            PlayButton.ButtonLocked = true;
        }
        else
        {
            PlayButton.ButtonLocked = false;
        }
    }

    public void PlayGame() {
        SaveList list = new SaveList();
        list.LevelItemListNew();
        list.PlayItems = playItems;
        GameInstance.SaveIndex = GameInstance.Save.Save(list);
    }








}
