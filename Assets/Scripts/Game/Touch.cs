using UnityEngine;
using System.Collections;
using System;

public class Touch : Base
{
    TouchEventArgs lastTouchArgs = null;

    void FixedUpdate()
    {
        SimpleInput();
    }
    /// <summary>
    /// Touch Action for all 2Dgame Objects in game if they have inherit ITouchSender.Touch
    /// </summary>
    void SimpleInput()
    {
        if (Input.GetMouseButton(0))
        {
            SendTouchInfoObject(Input.mousePosition, GestureTouch.Tap);
        }
        else {
            SendTouchOverTo();
        }
    }
    /// <summary>
    /// send touch method by interface implement to object
    /// </summary>
    void SendTouchInfoObject(Vector3 position, GestureTouch gest)
    {
        Ray ray = Camera.main.ScreenPointToRay(position);
        TouchEventArgs newTouchArgs = new TouchEventArgs();
        newTouchArgs.Hit = Physics2D.Raycast(ray.origin, ray.direction);
        if (lastTouchArgs == null)
        {
            newTouchArgs.Gesture = GestureTouch.First;
        }
        else
        {
            newTouchArgs.Gesture = gest;
        }
        SendTouchOverTo(newTouchArgs);
        if (newTouchArgs.Hit.transform != null)
        {
            if (newTouchArgs.Hit.transform.gameObject.GetComponent<ITouchSender>() != null)
            {
                newTouchArgs.Hit.transform.gameObject.GetComponent<ITouchSender>().Touch(this, newTouchArgs);
            }
        }
    }
    /// <summary>
    /// send end touch this object, and swap lastTouchArgs for new
    /// </summary>
    void SendTouchOverTo(TouchEventArgs newTouchArgs)
    {
        if (lastTouchArgs != null)
        {
            if (lastTouchArgs.Hit.transform != null)
            {
                if (lastTouchArgs.Hit.transform.gameObject.GetComponent<ITouchSender>() != null)
                {
                    if (!lastTouchArgs.Hit.transform.Equals(newTouchArgs.Hit.transform))
                    {
                        lastTouchArgs.Gesture = GestureTouch.End;
                        lastTouchArgs.Hit.transform.gameObject.GetComponent<ITouchSender>().Touch(this, lastTouchArgs);
                        lastTouchArgs = newTouchArgs;
                    }
                }
            }
        }
        else
        {
            lastTouchArgs = newTouchArgs;
        }
    }
    /// <summary>
    /// send end for lastTouchArgs
    /// </summary>
    void SendTouchOverTo()
    {
        if (lastTouchArgs != null)
        {
            if (lastTouchArgs.Hit.transform != null)
            {
                if (lastTouchArgs.Hit.transform.gameObject.GetComponent<ITouchSender>() != null)
                {
                    lastTouchArgs.Gesture = GestureTouch.End;
                    lastTouchArgs.Hit.transform.gameObject.GetComponent<ITouchSender>().Touch(this, lastTouchArgs);
                    lastTouchArgs = null;
                }
            }
        }
    }





}
