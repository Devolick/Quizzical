using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ScoreTable : DataTable {
    bool saveReady = false;

    protected override void _Awake()
    {
        base._Awake();
    }
    protected override void _Start()
    {
        base._Start();
        this.transform.GetComponentInParent<MenuScore>().Table = this;
    }
    public override void SwapRow(DataRow row)
    {
        base.SwapRow(row);
        FillRowIndexDistance(120);
    }
    void FillRowIndexDistance(float distance) {
        for (int i = 0; i < rows.Count; ++i) {
            float ySize = (rows[i].transform as RectTransform).sizeDelta.y;
            if (i == 0)
            {
                (rows[i].transform as RectTransform).anchoredPosition = new Vector2(0, (ySize * -1) * i);
            }
            else {
                if (rows[i - 1].Select)
                {
                    float yBefore = (rows[i - 1].transform as RectTransform).anchoredPosition.y;
                    (rows[i].transform as RectTransform).anchoredPosition = new Vector2(0, yBefore + (ySize * -1) + (distance * -1));
                }
                else {
                    float yBefore = (rows[i-1].transform as RectTransform).anchoredPosition.y;
                    (rows[i].transform as RectTransform).anchoredPosition = new Vector2(0,yBefore + (ySize * -1));
                }
            }
        }
    }
    public void ShowSave()
    {
        List<SaveList> list;
        if (GameInstance.Save.OpenSave(out list))
        {
            for (int i = 0; i < list.Count; ++i)
            {
                ScoreRow row = AddRow("ScoreRow",i) as ScoreRow;
                row.IndexSave = i;
                row.LevelText.text = "  LEVEL " + list[i].Level;
                string items = "";
                foreach (GameItem it in list[i].PlayItems)
                {
                    items += " " + it.ToString();
                }
                row.ItemsText.text = "  ITEMS " + items;

                //extra percent,date
                row.Extra1.Field("Found").text = "  FOUND " + (int)(list[i].Percent * 100) + "%";
                row.Extra1.Field("Played").text = "  PLAYED " + list[i].Date;
                //extra items found,not
                row.Extra2.Field("Found").text = "  FOUND " + list[i].Found;
                row.Extra2.Field("NotFound").text = "  NOT " + list[i].NotFound;

            }
        }
    }
    public void OffSelect() {
        if (SelectRow != null)
            SelectRow.CancelSelect();

        FillRowIndexDistance(120);
    }



}
