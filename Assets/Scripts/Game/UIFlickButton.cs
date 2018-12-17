using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System;

public abstract class UIFlickButton: UIObject
{
    protected AudioSource audioSource;
    Transform flick = null;
    protected bool buttonFlicked = false;
    protected bool buttonEnable = false;
    Vector2 sizeDelta;
    Delay delayMethod = null;

    public bool ButtonEnable {
        get { return !buttonFlicked; }
    }

    protected override void _Awake()
    {
        base._Awake();
        delayMethod = new Delay();
    }

    protected override void _Start()
    {
        base._Start();
        flick = this.transform.Find("FlickArea");
        sizeDelta = (flick as RectTransform).sizeDelta;
        audioSource = this.transform.GetComponent<AudioSource>();
    }

    protected abstract void Button();

    public override void Touch(object sender, EventArgs e)
    {
        if (buttonEnable) return;

        buttonEnable = true;
        buttonFlicked = !buttonFlicked;
        delayMethod.RegisterOnce(Button, 0.15f, true);
    }

    void FlickEffect() {
        if (buttonEnable) {
            if (buttonFlicked)
            {
                SetEffect(buttonFlicked, delayMethod.Percent);
                if (!delayMethod.Run) {
                    buttonEnable = false;
                }
            }
            else {
                SetEffect(buttonFlicked,delayMethod.Percent);
                if (!delayMethod.Run)
                {
                    buttonEnable = false;
                }
            }
        }
    }

    protected void SetEffect(bool flicked, float percent) {
        if (flicked)
        {
            Vector2 offsetSize = (flick as RectTransform).sizeDelta;
            float newProgressRight = offsetSize.x - (sizeDelta.x - (sizeDelta.x * percent));
            (flick as RectTransform).offsetMax += -new Vector2(newProgressRight, 0);
        }
        else {
            Vector2 offsetSize = (flick as RectTransform).sizeDelta;
            float newProgressRight = offsetSize.x - (sizeDelta.x * percent);
            (flick as RectTransform).offsetMax += -new Vector2(newProgressRight, 0);
        }
    }

    protected override void _Update()
    {
        base._Update();
        FlickEffect();
        delayMethod.PlayDelay(Time.fixedDeltaTime);
    }






}
