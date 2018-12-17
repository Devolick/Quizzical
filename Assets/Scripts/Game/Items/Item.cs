using UnityEngine;
using System.Collections;
using System;

public abstract class Item : Base, ITouchSender
{
    AudioSource audioSource;
    protected GameItem myName = GameItem.None;
    [SerializeField]
    protected int number = 1;
    protected SpriteRenderer select;
    protected SpriteRenderer render;
    protected bool found = false;
    protected bool selectFound = false;
    protected int filterNumberMax = 4;

    public GameItem MyName {
        get { return myName; }
    }
    public int Number {
        get { return number; }
    }
    public int FilterNumberMax {
        get { return filterNumberMax; }
    }
    protected override void _Start()
    {
        base._Start();
        this.transform.parent = GameObject.Find("Table").GetComponent<Table>().transform;
        select = this.transform.Find("Select").GetComponent<SpriteRenderer>();
        render = this.transform.GetComponent<SpriteRenderer>();
        Hide(true);

        audioSource = this.transform.GetComponent<AudioSource>();
    }
    public virtual void Touch(object sender, EventArgs e)
    {
        if (selectFound || select.enabled ||
            GameState.Status != GameStatus.Play)
            return;

        SelectItem();
        if(GameInstance.Effects)
            audioSource.Play();
    }
    /// <summary>
    /// select item if is not seleted
    /// </summary>
   protected void SelectItem() {
        if (SwapItem.Select == null)
        {
            SwapItem.Select = this;
        }
        else if (!SwapItem.Select.Equals(this)) {
            SwapItem.Select.UnSelectItem();
            SwapItem.Select = this;
        }
        select.enabled = true;
        
        UserInterface.CellWindowUI.EnableChoice(this, true);
    }
    /// <summary>
    /// Unselect item if it's selected
    /// </summary>
    public void UnSelectItem() {
        select.enabled = false;
        SwapItem.Select = null;
    }
    /// <summary>
    /// Filter new item number
    /// </summary>
    /// <param _name="number"></param>
    public int FilterNumber(int number) {
        if (number < 1)
        {
            number = filterNumberMax;
        }
        else if (number > filterNumberMax)
        {
            number = 1;
        }
        return number;
    }
    public int RandNumber() {
        return UnityEngine.Random.Range(1, filterNumberMax+1);
    }
    /// <summary>
    /// Show or Hide item at Table
    /// </summary>
    /// <param _name="hide"></param>
    public void Hide(bool hide) {
        Sprite sp = null;
        if (hide)
        {
            if (SpriteResources.GetSprite(ref sp,"Item"+ myName.ToString()))
            {
                render.sprite = sp;
                select.enabled = false;
            }
        }
        else {
            if (SpriteResources.GetSprite(ref sp, myName.ToString() + number))
            {
                render.sprite = sp;
                select.enabled = false;
            }
        }
    }
    /// <summary>
    /// Set found item, from cellwindow
    /// </summary>
    /// <param _name="number"></param>
    public void Found(int number) {
        selectFound = true;

        if (this.number == number)
        {
            found = true;
            GameState.GameLevelList.ItemFound(myName, true);
        }
        else {
            found = false;
            GameState.GameLevelList.ItemFound(myName, false);
        }
        Sprite sp = null;
        if (SpriteResources.GetSprite(ref sp, myName.ToString() + this.number))
        {
            render.sprite = sp;
        }
        UnSelectItem();
        FoundSelect();
        SwapItem.Select = null;
    }
    public void FoundSelect()
    {
        select.enabled = true;
        Sprite sp = null;
        if (found)
        {
            if (SpriteResources.GetSprite(ref sp, "AnswerOK"))
            {
                select.sprite = sp;
            }
        }
        else
        {
            if (SpriteResources.GetSprite(ref sp, "AnswerX"))
            {
                select.sprite = sp;
            }
        }
        select.sortingOrder = 3;
    }
    protected override void _Update()
    {
        base._Update();
        
    }










}
