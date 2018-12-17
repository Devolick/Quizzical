using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class DataTable : Base {

    protected List<DataRow> rows;
    DataRow selectRow;

    public DataRow SelectRow {
        get { return selectRow; }
    }

    protected override void _Awake()
    {
        base._Awake();
        rows = new List<DataRow>();
    }
    protected override void _Start()
    {
        base._Start();

    }
    public virtual DataRow AddRow(string rowPrefabName, int index) {
        DataRow row = null;
        SpriteResources.GetPrefab<DataRow>(rowPrefabName, out row);
        row = Instantiate(row) as DataRow;
        row.transform.parent = this.transform;
        row.transform.localScale = new Vector3(1, 1, 1);
        rows.Add(row);
        FillRowIndex(row,index);

        return row;
    }
    void FillRowIndex(DataRow row, int index) {
        float ySize = (row.transform as RectTransform).sizeDelta.y;
        (row.transform as RectTransform).anchoredPosition = new Vector2(0,(ySize *-1) * index);
    }
    public virtual void SwapRow(DataRow row) {
        if (selectRow == null)
        {
            selectRow = row;
        }
        else if (!selectRow.Equals(row)) {
            selectRow.CancelSelect();
            selectRow = row;
        }
    }








}
