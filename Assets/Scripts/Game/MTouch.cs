using UnityEngine;
using System.Collections.Generic;
using System.Collections;
using System;

public class MTouch : Base
{
    TouchEventArgs lastSwapArgs = null;
    bool firstTouch = false;
    bool firstTargetChanged = false;

    protected override void _Start()
    {
        base._Start();
    }

    protected override void _Update()
    {
        base._Update();
        MInput();
    }

    void MInput()
    {
        if (Input.touchCount > 0)
        {
            foreach (UnityEngine.Touch t in Input.touches)
            {
                TouchEventArgs resultArgs;
                FillScreenObject(out resultArgs, t);
                FirstPhase(resultArgs);
                TapTarget(lastSwapArgs, resultArgs);
                MovePhase(resultArgs, t);
            }
        }
        else
        {
            TapPhase(lastSwapArgs);
            EndPhase(lastSwapArgs);
            lastSwapArgs = null;
        }
    }
    void FillScreenObject(out TouchEventArgs resultArgs, UnityEngine.Touch t) {
        resultArgs = new TouchEventArgs();
        Ray ray = Camera.main.ScreenPointToRay(t.position);
        resultArgs.Hit = Physics2D.Raycast(ray.origin, ray.direction);
    }
    void FirstPhase(TouchEventArgs resultArgs)
    {
        if (!firstTouch)
        {
            firstTouch = true;
            firstTargetChanged = false;
            if (resultArgs.Hit.transform != null) {
                resultArgs.Gesture = GestureTouch.First;
                MobileTouchToObject(resultArgs);
            }

            this.lastSwapArgs = resultArgs;
        }
    }
    void MovePhase(TouchEventArgs resultArgs, UnityEngine.Touch t) {
        if (t.phase == TouchPhase.Moved) {
            if (resultArgs.Hit.transform != null)
            {
                resultArgs.Gesture = GestureTouch.Move;
                MobileTouchToObject(resultArgs);
            }
            MoveSwap(lastSwapArgs, resultArgs);
            this.lastSwapArgs = resultArgs;
        }
    }
    void MoveSwap(TouchEventArgs lastTouchArgs, TouchEventArgs resultArgs)
    {
        if(!resultArgs.NullEquals(lastTouchArgs)){
            if (lastTouchArgs.Hit.transform != null)
            {
                resultArgs.Gesture = GestureTouch.End;
                MobileTouchToObject(resultArgs);
            }
            if (resultArgs.Hit.transform != null)
            {
                resultArgs.Gesture = GestureTouch.First;
                MobileTouchToObject(resultArgs);
            }
        }
    }
    void TapTarget(TouchEventArgs lastTouchArgs, TouchEventArgs resultArgs) {
        if (!resultArgs.NullEquals(lastTouchArgs)) {
            firstTargetChanged = true;
        }
    }
    void TapPhase(TouchEventArgs resultArgs)
    {
        if (resultArgs.Hit.transform != null && !firstTargetChanged)
        {
            resultArgs.Gesture = GestureTouch.Tap;
            MobileTouchToObject(resultArgs);
        }
    }
    void EndPhase(TouchEventArgs resultArgs) {
        if (resultArgs.Hit.transform != null)
        {
            resultArgs.Gesture = GestureTouch.End;
            MobileTouchToObject(resultArgs);
        }
        firstTouch = false;
        firstTargetChanged = false;
    }
    void MobileTouchToObject(TouchEventArgs resultArgs)
    {
        if (resultArgs.Hit.transform != null)
        {
            ITouchSender touchSend = resultArgs.Hit.transform.gameObject.GetComponent<ITouchSender>();
            if (touchSend != null)
            {
                touchSend.Touch(this, resultArgs);
            }
        }
    }



}
