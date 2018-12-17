using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[RequireComponent(typeof(GeneratePositions))]
public class SpawnItems : Base {

    public int widthRadius = 0;
    public int heightRadius = 0;
    public float findCenterX = 0;
    public float findCenterY = 0;

    public int spawnItems = 0;
    bool spawned = false;

    GeneratePositions generatePositions = null;

    List<GameItem> itemArray;

    public List<GameItem> Items {
        set {
            itemArray = new List<GameItem>(value);
        }
    }

    public bool Spawned {
        get {
            if (spawned)
            {
                spawned = false;
                return true;
            }
            else {
                return false;
            }
        }
    }

    protected override void _Start()
    {
        base._Start();
        generatePositions = this.GetComponent<GeneratePositions>();
    }

    public void CountOfSpawn(int spawnItems = 0) {
        generatePositions.Clear();
        generatePositions.MixBlockGenArr();
        generatePositions.ListAdditionPositions();
        this.spawnItems = spawnItems;
    }

    GameItem RandItem() {
        return itemArray[UnityEngine.Random.Range(0, itemArray.Count)];
    }

    public void Spawn() {
        if (spawnItems > 0)
        {
            --spawnItems;
            Item item;
            SpriteResources.GetPrefab<Item>(RandItem().ToString(),out item);
            Instantiate(item, generatePositions.RandPosition(widthRadius,heightRadius,findCenterX,findCenterY), Quaternion.identity);
        }
        else if (spawnItems <= 0)
        {
            spawnItems = 0;
            spawned = true;
        }
    }

}
