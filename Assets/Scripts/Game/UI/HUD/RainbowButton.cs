using UnityEngine;
using System.Collections;
using System;

public class RainbowButton : UIObject
{
    AudioSource audioSource;
    public Transform centerPoint;
    private Vector2 firstTouch;
    private Vector2 nextTouch;
    private bool enableSwap = false;
    [SerializeField]
    private int degreeRot = 61;


    public bool EnableSwap {
        get { return enableSwap; }
        set { enableSwap = value; }
    }

    protected override void _Start()
    {
        base._Start();
        centerPoint = this.transform.Find("center").transform;
        audioSource = this.transform.GetComponent<AudioSource>();

        DetectDegreeOfRot();
    }

    void DetectDegreeOfRot() {     
        float inch = Mathf.Sqrt((Screen.width * Screen.width) + (Screen.height * Screen.height));
        float sizeDevice = inch / Screen.dpi;
        if (sizeDevice >= 4.5f)
        {
            int morePoints = (int)(sizeDevice - 4.5f);
            degreeRot = (int)( 61 - (61 / (2 + morePoints)));
        }
    }

    public override void Touch(object sender, EventArgs e)
    {
        TouchEventArgs args = e as TouchEventArgs;
        if (!enableSwap &&
            (!(args.Gesture == GestureTouch.Move) ||
            !(args.Gesture == GestureTouch.First) ||
            !(args.Gesture == GestureTouch.End)))
            return;

        if (args.Gesture == GestureTouch.First)
        {
            firstTouch = args.Hit.point;
            nextTouch = firstTouch;
            centerPoint.rotation = Quaternion.Euler(0, 0, LookAt(firstTouch, centerPoint));
        }
        else
        {
            nextTouch = args.Hit.point;
            int resultSpawnItems;
            if (SwapAngle(out resultSpawnItems))
            {
                firstTouch = nextTouch;
                centerPoint.rotation = Quaternion.Euler(0, 0, LookAt(firstTouch, centerPoint));
                UserInterface.CellWindowUI.SwitchNumber(resultSpawnItems);
            }
        }
    }
    float LookAt(Vector3 target,Transform center) {
        Vector2 dir = target - center.position;
        dir.Normalize();
        float rot_z = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        return rot_z;
    }
    bool SwapAngle(out int result) {
        Vector2 sp1 = new Vector2(firstTouch.x - centerPoint.position.x, firstTouch.y - centerPoint.position.y);
        Vector2 sp2 = new Vector2(nextTouch.x - centerPoint.position.x, nextTouch.y - centerPoint.position.y);
        float angle = Vector2.Angle(sp1, sp2);
        Vector2 sum = sp2 - sp1;
        int sign = (Mathf.Atan2(sum.y, sum.x) < 0 ? -1 : 1);
        result = (int)((angle / degreeRot) * sign);

        if (result != 0) {
            if (GameInstance.Effects)
                audioSource.Play();
            return true;
        }

        return false;
    }

}
