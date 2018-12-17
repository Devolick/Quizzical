using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System;

public abstract class UIButton: UIObject
{
    AudioSource audioSource;
    protected Image imgButton;
    public Sprite pressed;
    public Sprite released;
    protected Delay delayMethod = null;
    protected bool buttonEnable = false;
    string test = "";

    protected override void _Awake()
    {
        base._Awake();
        delayMethod = new Delay();
        imgButton = this.GetComponent<Image>();
    }

    protected override void _Start()
    {
        base._Start();
        audioSource = this.transform.GetComponent<AudioSource>();
    }

    void Button() {
        buttonEnable = false;
        imgButton.sprite = released;
        ChangeButton();
    }

    protected abstract void ChangeButton();

    public override void Touch(object sender, EventArgs e)
    {
        if (buttonEnable) return;

        buttonEnable = true;
        delayMethod.RegisterOnce(Button, 0.25f,true);
        imgButton.sprite = pressed;

        if(GameInstance.Effects)
            audioSource.Play();
    }

    protected override void _Update()
    {
        base._Update();
        delayMethod.PlayDelay(Time.fixedDeltaTime);
    }

}
