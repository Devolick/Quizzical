using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ScoreExtraRow : Base {


    public Text Field(string child) {
       return this.transform.Find(child).GetComponent<Text>();
    }




















}
