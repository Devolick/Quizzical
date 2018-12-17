using UnityEngine;
using System.Collections;

public class Transfer : MonoBehaviour {
    static Transfer instance;

    void Awake()
    {
        LevelTransfer();
    }

    void LevelTransfer()
    {
        if (instance == null)
        {
            GameObject.DontDestroyOnLoad(gameObject);
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
    }


}
