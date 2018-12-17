using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using System;

public class LoadingScreen : Base {

    BoxCollider2D collideBox2D;
    LoadingText loadingText;
    int currentLevel = 0;
    Delay delayMethod;
    bool sceneLoaded=false;
    AudioSource audioSource;
    bool _inGame = false;

    public bool SceneLoaded {
        get { return sceneLoaded; }
    }
    protected override void _Awake()
    {
        base._Awake();
        ShowLoadingScreen(true);
        currentLevel = SceneManager.GetActiveScene().buildIndex;
        delayMethod = new Delay();
        LockByCollider();
    }
    protected override void _Start()
    {
        base._Start();
        loadingText = this.transform.Find("BigQuestion").Find("LoadingText").GetComponent<LoadingText>();
        ShowLoadingScreen(false);
        OpenScene(currentLevel);

        audioSource = this.transform.GetComponent<AudioSource>();
    }
    public void LockByCollider()
    {
        collideBox2D = this.gameObject.AddComponent<BoxCollider2D>();
        collideBox2D.size = new Vector2(1200, 1200);
        collideBox2D.enabled = false;
    }
    public void OpenScene(int number) {
        sceneLoaded = false;
        collideBox2D.enabled = true;
        DetectSound(number);
        if (currentLevel != number)
        {
            ShowLoadingScreen(true);
            Load(number);
            ShowAdsRandom();
        }
        else {
            ShowLoadingScreen(true);
            delayMethod.RegisterOnce(LoadedScene, 3, true);
        }
    }
    void ShowAdsRandom() {
        if (UnityEngine.Random.Range(0, 100) > 80)
        {
            //AdManager.Ad.ShowAd(true);
        }
        else
        {
            //AdManager.Ad.ShowAd(false);
        }
    }
    void DetectSound(int number) {
        if (number == 0)
        {
            _inGame = false;
        }
        else {
            _inGame = true;
        }
    }
    void ShowLoadingScreen(bool show) {
        foreach (Transform trs in this.transform)
        {
            trs.gameObject.SetActive(show);
        }
    }
    void Load(int number) {
        this.currentLevel = number;
        delayMethod.RegisterOnce(LoadedScene, 3, true);
        SceneManager.LoadScene(number);
    }   
    void LoadedScene() {
        loadingText.ProgressOver();
        ShowLoadingScreen(false);
        sceneLoaded = true;
        collideBox2D.enabled = false;
    }
    void LoadingProgress() {
        if (delayMethod.Run) {
            loadingText.ShowProgress(delayMethod);
        }
        SoundPower();
    }
    void SoundPower() {
        if (_inGame)
        {
            audioSource.volume = 1 - delayMethod.Percent;
        }
        else
        {
            audioSource.volume = delayMethod.Percent;
        }
    }
    protected override void _Update()
    {
        base._Update();
        LoadingProgress();
        delayMethod.PlayDelay(Time.fixedDeltaTime);
    }




}
