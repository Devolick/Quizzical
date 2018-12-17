using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

[Serializable]
public class SaveList {

    List<LevelItems> levelList;
    List<GameItem> playItems;
    DateTime dateTime;

    public SaveList() {
        levelList = new List<LevelItems>();
        playItems = new List<GameItem>();
        dateTime = DateTime.Now;
    }

    public int Level {
        get { return levelList.Count; }
    }

    public DateTime Date {
        get { return dateTime; }
    }

    public float Percent {
        get
        {
            if (levelList.Count > 1)
            {
                int found = Found;
                int notFound = NotFound;
                return ((float)found / (found + notFound));
            }

            return 0;
        }
    }
    public int Found {
        get
        {
            if (levelList.Count > 1)
            {
                int found = 0;
                for (int i = 0; i < levelList.Count - 1; ++i)
                {
                    for (int u = 0; u < levelList[i].Items.Count; ++u)
                    {
                        if (levelList[i].Items[u].Value)
                        {
                            ++found;
                        }
                    }
                }
                return found;
            }
            return 0;
        }
    }
    public int NotFound {
        get {
            if (levelList.Count > 1)
            {
                int notFound = 0;
                for (int i = 0; i < levelList.Count - 1; ++i)
                {
                    for (int u = 0; u < levelList[i].Items.Count; ++u)
                    {
                        if (!levelList[i].Items[u].Value)
                        {
                            ++notFound;
                        }
                    }
                }
                return notFound;
            }
            return 0;
        }
    }

    public List<GameItem> PlayItems {
        get { return playItems; }
        set { playItems = value; }
    }

    public LevelItems LevelItemListNew()
    {
        dateTime = DateTime.Now;
        levelList.Add(new LevelItems());
        return levelList[levelList.Count - 1];
    }

    public LevelItems LevelItemList() {
        dateTime = DateTime.Now;
        if (levelList.Count < 1) {
            return LevelItemListNew();
        }
        
        return levelList[levelList.Count - 1];
    }

    public void DropItemListLevel()
    {
        dateTime = DateTime.Now;
        if (levelList.Count >= 1)
        {
            levelList.RemoveAt(levelList.Count - 1);
        }
        if (levelList.Count < 1)
        {
            LevelItemListNew();
        }
    }

    public void RefreshListLevel() {
        dateTime = DateTime.Now;
        levelList[levelList.Count - 1].Items.Clear();
    }

    public void ItemFound(GameItem item, bool found) {
        LevelItemList().ItemFound(new KeyValuePair<GameItem, bool>(item, found));
    }

    public bool ContainsItems(SaveList list) {
        bool contained = false;
        if (playItems.Count != list.playItems.Count) { return false; }
        for (int i = 0; i < playItems.Count; ++i) {
            for (int y = 0; y < playItems.Count; ++y) {
                if (playItems[i] == list.playItems[y]) {
                    contained = true;
                }
            }
            if (!contained) {
                return false;
            }
            contained = false;
        }

        return true;
    }











}
