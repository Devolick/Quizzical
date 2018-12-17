using UnityEngine;
using System.Collections;

public abstract class MenuWindow : Base {


    public virtual void Show() {
        if (UserMenuRoot.OpenedWindow != null) {
            UserMenuRoot.OpenedWindow.transform.localPosition = this.transform.localPosition;
            UserMenuRoot.OpenedWindow.OffWindow();
        }
        UserMenuRoot.OpenedWindow = this;
        UserMenuRoot.OpenedWindow.transform.localPosition = new Vector2(0, 0);
    }

    protected virtual void OffWindow() { }




}
