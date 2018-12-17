using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class LoadingText : Base {

    Transform progress;
    public float sizeBar = 0;

    protected override void _Start()
    {
        base._Start();
        progress = this.transform.Find("Progress").transform;
    }

    public void ShowProgress(Delay delayMethod) {
        if (delayMethod.Run)
        {
            (progress as RectTransform).anchoredPosition = new Vector2(((sizeBar * delayMethod.Percent) / 2) + 3, 1);
            float deltaY = (progress as RectTransform).sizeDelta.y;
            (progress as RectTransform).sizeDelta = new Vector2(sizeBar * delayMethod.Percent, deltaY);
        }
    }

    public void ProgressOver() {
        float deltaY = (progress as RectTransform).sizeDelta.y;
        (progress as RectTransform).sizeDelta = new Vector2(0, deltaY);
    }



}
