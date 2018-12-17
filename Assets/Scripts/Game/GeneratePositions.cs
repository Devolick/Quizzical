using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GeneratePositions : Base {

    BlockGenerator[] blockGenBy4 = new BlockGenerator[4];
    BlockGenerator blockTemp = new BlockGenerator();
    List<Vector2> gridListOfPositions = new List<Vector2>();

    protected override void _Awake()
    {
        InitGrid();
    }

    /// <summary>
    /// initialize viewport by 4 place for random in center poisitons
    /// </summary>
    void InitGrid()
    {
        blockGenBy4[0] = new BlockGenerator(
               3, 5, 1, 1);
        blockGenBy4[1] = new BlockGenerator(
                    4, 5, 5, 1);
        blockGenBy4[2] = new BlockGenerator(
                    3, 6, 1, 10);
        blockGenBy4[3] = new BlockGenerator(
                    4, 6, 5, 10);
    }

    /// <summary>
    /// Mix array by blockTemp for random place by 4 at viewport
    /// </summary>
    public void MixBlockGenArr()
    {
        for (int i = 0; i < blockGenBy4.Length; i++)
        {
            int index = UnityEngine.Random.Range(0, blockGenBy4.Length);
            blockTemp = blockGenBy4[index];
            blockGenBy4[index] = blockGenBy4[i];
            blockGenBy4[i] = blockTemp;
        }
    }

    public void ListAdditionPositions()
    {
        bool loop = true;
        int countLs = 0;
        while (loop)
        {
            loop = false;
            for (int i = 0; i < blockGenBy4.Length; i++)
            {
                if (blockGenBy4[i].NextFound)
                {
                    blockGenBy4[i].DeterminationNum(gridListOfPositions);
                    loop = true;
                    ++countLs;
                }
            }
        }
    }

    public Vector3 RandPosition(int widthRadius=0, int heightRadius=0,float findCenterX=0,float findCenterY=0)
    {
        Vector3 pos = Vector3.zero;
        int index = 0;
        if (gridListOfPositions.Count > 8)
        {
            index = UnityEngine.Random.Range(0, 8);
        }
        else
        {
            index = UnityEngine.Random.Range(0, gridListOfPositions.Count);
        }
        pos = gridListOfPositions[index];
        pos.x = (float)(findCenterX - ((widthRadius * pos.x) / 100f));
        pos.y = (float)(findCenterY - ((heightRadius * pos.y) / 100f));
        gridListOfPositions.RemoveAt(index);
        return pos;
    }

    public void Clear() {
        gridListOfPositions.Clear();
        for (int i = 0; i < blockGenBy4.Length; i++) {
            blockGenBy4[i].Clear();
        }
    }





}
