using UnityEngine;
using System.Collections;

public class MenuScore : MenuWindow {
    bool loadSave = false;

    public ScoreTable Table
    {
        get;
        set;
    }

    [SerializeField]
    float testElapsedTime = 0;
    bool teststop = true;

    protected override void _Start()
    {
        base._Start();
        
    }
    protected override void _Update()
    {
        base._Update();
        testElapsedTime += Time.fixedDeltaTime;
        if (testElapsedTime >= 3f) {
            testElapsedTime = 3f;
            if (!teststop)
            {
                teststop = true;

            }
        }
    }
    public override void Show()
    {
        base.Show();
        if (!loadSave)
        {
            loadSave = true;
            Table.ShowSave();
        }
    }
    protected override void OffWindow()
    {
        base.OffWindow();
        Table.OffSelect();
    }


}
