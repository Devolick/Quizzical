using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System;

public abstract class UIMessage : Base {

    AudioSource audioSource;
    protected Image background;
    BoxCollider2D collideBox2D;
    Image title;
    protected Delay delay;
    bool show = false;
    bool enableEffectBackground=false;

    Vector2 OffsetXMinMax;

    protected override void _Awake()
    {
        base._Awake();
        LockByCollider();

    
        OffsetXMinMax.x = (this.transform as RectTransform).offsetMin.x;
        OffsetXMinMax.y = (this.transform as RectTransform).offsetMax.x;
    }

    protected override void _Start()
    {
        base._Start();
        background = this.transform.Find("Background").GetComponent<Image>();
        title = this.transform.Find("Title").GetComponent<Image>();
        delay = new Delay();
        audioSource = this.transform.GetComponent<AudioSource>();

        DefaultHideAll();
    }
    public void LockByCollider()
    {
        collideBox2D = this.gameObject.AddComponent<BoxCollider2D>();
        collideBox2D.size = new Vector2(3000, 3000);
        collideBox2D.enabled = false;
    }
    public void Show(bool show) {
        Vector2 offsetMin = (this.transform as RectTransform).offsetMin;
        (this.transform as RectTransform).offsetMin = new Vector2(0, offsetMin.y);
        Vector2 offsetMax = (this.transform as RectTransform).offsetMin;
        (this.transform as RectTransform).offsetMax = new Vector2(0, offsetMax.y);

        enableEffectBackground = true;
        if (show)
        {
            Color cl = background.color;
            background.color = new Color(cl.r, cl.g, cl.b, 0);
            this.show = show;
            collideBox2D.enabled = true;
            background.enabled = true;
            delay.RegisterOnce(Open, 1f, true);
        }
        else {
            this.show = show;
            delay.RegisterOnce(Over, 1f, true);
            Close();
        }
    }
    protected virtual void Open() {
        enableEffectBackground = false;
        title.gameObject.SetActive(true);
        if (GameInstance.Effects)
            audioSource.Play();
    }
    protected virtual void Close()
    {
        title.gameObject.SetActive(false);
    }
    void Over() {
        UserInterface.ConfirmButtonUI.BackConfirm();
        DefaultHideAll();
    }
    protected virtual void DefaultHideAll() {
        collideBox2D.enabled = false;
        background.enabled = false;
        title.gameObject.SetActive(false);

        Vector2 offsetMin = (this.transform as RectTransform).offsetMin;
        (this.transform as RectTransform).offsetMin = new Vector2(OffsetXMinMax.x, offsetMin.y);
        Vector2 offsetMax = (this.transform as RectTransform).offsetMin;
        (this.transform as RectTransform).offsetMax = new Vector2(OffsetXMinMax.y, offsetMax.y);
    }
    protected void BackgroundEffect() {
        if (delay.Run && enableEffectBackground) {
            if (show)
            {
                Color cl = background.color;
                background.color = new Color(cl.r, cl.g, cl.b, delay.Percent / 2f);
            }
            else {
                Color cl = background.color;
                background.color = new Color(cl.r, cl.g, cl.b, (1f - delay.Percent) / 2f);
            }
        }
    }
    protected override void _Update()
    {
        base._Update();
        BackgroundEffect();
        delay.PlayDelay(Time.fixedDeltaTime);
    }

}
