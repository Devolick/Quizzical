using UnityEngine;
using System.Collections;

public class UserMenuRoot : Base {
    static UserMenuRoot instance = null;
    static MenuWindow openedWindow = null;

    public static MenuWindow OpenedWindow {
        set { openedWindow = value; }
        get { return openedWindow; }
    }

    protected override void _Start()
    {
        base._Start();

        instance = this;
        FillLayer = false;

        Canvas canvas = this.transform.GetComponent<Canvas>();
        canvas.renderMode = RenderMode.ScreenSpaceCamera;
        canvas.worldCamera = GameObject.Find("Camera").GetComponent<Camera>();
    }

    public static void Show<T>() where T : MenuWindow
    {
        foreach (Transform trs in instance.transform)
        {
            T ob = trs.GetComponent<T>();
            if (ob != null)
            {
                ob.Show();
                break;
            }
        }
    }


}
