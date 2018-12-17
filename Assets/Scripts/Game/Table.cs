using UnityEngine;
using System.Collections;
using System;

[RequireComponent(typeof(SpawnItems))]
[RequireComponent(typeof(GameState))]
[RequireComponent(typeof(SwapItem))]
[RequireComponent(typeof(SpriteResources))]
[RequireComponent(typeof(GameRule))]
public class Table : Base {
    public const int MAX_ITEMS = 50;
    SpawnItems spawnItems = null;
    bool generateStep = true;
    Delay delayMethod = null;


    protected override void _Awake()
    {
        base._Awake();
        delayMethod = new Delay();
    }
    protected override void _Start()
    {
        base._Start();
        spawnItems = this.GetComponent<SpawnItems>();
        GameState.Status = GameStatus.LevelData;
        generateStep = true;
    }
    void GenerateLevel()
    {
        if (GameState.Status == GameStatus.LevelData)
        {
            GameState.GameLevelList = GameInstance.Save.OpenSave(GameInstance.SaveIndex); //only this here
            spawnItems.Items = GameState.GameLevelList.PlayItems;
            GameState.Status = GameStatus.Rule; //this;
        }
    }
    /// <summary>
    /// Call once to spawn items at Table
    /// </summary>
    void GenerateItems() {
        if (GameState.Status == GameStatus.Generate)
        {
            if (generateStep)
            {
                ClearItems();
                generateStep = false;
                spawnItems.CountOfSpawn(GameState.GameLevelList.Level);
                delayMethod.RegisterOnce(PlaceToTable, 0.25f, false);
            }
        }
    }
    void PlaceToTable()
    {
        spawnItems.Spawn();
        if (spawnItems.Spawned)
        {
            delayMethod.Stop();
            generateStep = true;
            ShowItems(true);
            GameState.Status = GameStatus.ShowIt;
        }
    }
    void HideItAndPlay() {
        if (GameState.Status == GameStatus.HideIt) {
            ShowItems(false);
            GameState.Status = GameStatus.Play;
        }
    }
    void ShowItems(bool show)
    {
        Item[] it = this.transform.GetComponentsInChildren<Item>();
        for (int i = 0; i < it.Length; ++i)
        {
            it[i].Hide(!show);
        }
    }
    void ClearItems() {
        Item[] it = this.transform.GetComponentsInChildren<Item>();
        for (int i = 0; i < it.Length; ++i) {
            Destroy(it[i].gameObject);
        }
    }
    protected override void _Update()
    {
        base._Update();
        if (GameInstance.LoadGame.SceneLoaded)
        {
            GenerateLevel();
            GenerateItems();
            HideItAndPlay();
            delayMethod.PlayDelay(Time.fixedDeltaTime);
        }
        
    }

}
