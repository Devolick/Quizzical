using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

[RequireComponent(typeof(SaveGame))]
public class GameInstance : Base {

    static GameInstance instance;

    SaveGame saveGame;
    LoadingScreen loadingScreen;
    bool saveMode = false;
    int saveIndex = 0;

    public static LoadingScreen LoadGame {
        get { return instance.loadingScreen; }
    }
    public static SaveGame Save {
        get { return instance.saveGame; }
    }
    public static int SaveIndex {
        get { return instance.saveIndex; }
        set { instance.saveIndex = value; }
    }

    public static bool Effects {
        get;
        set;
    }

    protected override void _Awake()
    {
        base._Awake();
        LevelTransfer();
        FillTouch();
        saveGame = this.transform.GetComponent<SaveGame>();
        loadingScreen = this.transform.Find("LoadingScreen").GetComponent<LoadingScreen>();
        FillTouch();
    }
    void FillTouch() {
#if UNITY_EDITOR_WIN || UNITY_STANDALONE_WIN
        this.transform.gameObject.AddComponent<Touch>();
#elif UNITY_ANDROID || UNITY_WINRT || UNITY_WINRT_8_0 ||UNITY_WINRT_8_1||UNITY_WINRT_10_0
        this.transform.gameObject.AddComponent<MTouch>();
#endif
    }
    protected override void _Start()
    {
        base._Start();
    }
    void OnLevelWasLoaded(int level) {
        Canvas canvas = this.transform.GetComponent<Canvas>();
        canvas.renderMode = RenderMode.ScreenSpaceCamera;
        canvas.worldCamera = GameObject.Find("Camera").GetComponent<Camera>();
    }
    void LevelTransfer() {
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
