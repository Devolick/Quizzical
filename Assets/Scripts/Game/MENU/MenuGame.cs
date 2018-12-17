using UnityEngine;
using System.Collections;

public interface IShowLock {
    void CheckSave();
}

public class MenuGame : MenuWindow {

    public override void Show()
    {
        base.Show();
        foreach (Transform trs in this.transform) {
            IShowLock button = trs.GetComponent<UIButton>() as IShowLock;
            if (button != null) {
                button.CheckSave();
            }
        }
    }


}
