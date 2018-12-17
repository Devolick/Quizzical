using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SpriteResources : Base
{
    static SpriteResources instance = null;

    private List<Sprite> sprites;

    protected override void _Awake()
    {
        instance = this;
        LoadResources();
    }

    void LoadResources()
    {
        instance.sprites = new List<Sprite>();

        foreach (Sprite s in Resources.LoadAll<Sprite>("sprite_final"))
        {
            instance.sprites.Add(s);
        }
    }

    public static bool GetSprite(ref Sprite sprite,string name)
    {
        foreach (var s in instance.sprites)
        {
            if (s.name == name)
            {
                sprite = s;
                return true;
            }
        }

        return false;
    }

    public static bool GetPrefab<T>(string name, out T prefab) where T : MonoBehaviour {
        prefab = null;
        GameObject obj = Resources.Load("Prefabs/" + name,typeof(GameObject)) as GameObject;
        if (obj != null) {
           prefab = obj.GetComponent<T>();
        }
        if (obj == null) return false;
        else return true;
    }


}
