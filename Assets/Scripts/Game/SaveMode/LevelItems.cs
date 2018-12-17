using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

[Serializable]
public class LevelItems {
    List<KeyValuePair<GameItem,bool>> items;



    public List<KeyValuePair<GameItem, bool>> Items {
        get { return items; }
    }

    public LevelItems() {
        items = new List<KeyValuePair<GameItem, bool>>();
    }

    public void ItemFound(KeyValuePair<GameItem,bool> item)
    {
        items.Add(item);
    }












}
