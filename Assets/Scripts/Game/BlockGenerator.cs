using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;

struct BlockGenerator
{
    int startX;
    int startY;
    int endX;
    int endY;
    int nowX;
    int nowY;
    int stepX;
    int stepY;
    int counter;

    public BlockGenerator(int startX, int startY, int endX, int endY)
    {
        this.startX = startX;
        this.startY = startY;
        this.endX = endX;
        this.endY = endY;
        this.nowX = startX;
        this.nowY = startY;
        this.stepX = this.nowX;
        this.stepY = this.nowY;
        this.counter = 0;
    }

    public int Counter
    {
        get { return counter; }
    }

    public bool NextFound
    {
        get
        {
            return PositiveNumber(endX, endY, stepX, stepY);
        }
    }

    public void Clear()
    {
        this.nowX = startX;
        this.nowY = startY;
        this.stepX = this.nowX;
        this.stepY = this.nowY;
        this.counter = 0;
    }

    int PositiveNumber(int first, int last)
    {
        if (first < last)
            return 1;
        else if (first > last)
            return -1;

        return 0;
    }

    bool PositiveNumber(int firstX, int firstY, int lastX, int lastY)
    {
        if (firstX == lastX && firstY == lastY)
            return false;
        return true;
    }

    public void DeterminationNum(List<Vector2> list)
    {
        if (PositiveNumber(stepY, nowY) != 0)
        {
            //Console.SetCursorPosition(nowX, stepY);
            ++counter;
            list.Add(new Vector2(nowX, stepY));
            stepY += PositiveNumber(stepY, endY);
        }
        if (PositiveNumber(stepX, nowX) != 0)
        {
            //Console.SetCursorPosition(stepX, nowY);
            ++counter;
            list.Add(new Vector2(stepX, nowY));
            stepX += PositiveNumber(stepX, endX);
        }

        if (!PositiveNumber(endX, endY, stepX, stepY))
        {
            // Console.SetCursorPosition(endX, endY);
            ++counter;
            list.Add(new Vector2(endX, endY));
            return;
            //end point
        }
        else
        if (!PositiveNumber(nowX, nowY, stepX, stepY))
        {
            //Console.SetCursorPosition(stepX, stepY);
            ++counter;
            list.Add(new Vector2(stepX, stepY));
            if (PositiveNumber(nowX, endX) != 0)
            {
                stepY = startY;
            }
            else
            {
                stepY += PositiveNumber(stepY, endY);
            }

            if (PositiveNumber(nowY, endY) != 0)
            {
                stepX = startX;
            }
            else
            {
                stepX += PositiveNumber(stepX, endX);
            }

            nowX += PositiveNumber(nowX, endX);
            nowY += PositiveNumber(nowY, endY);
        }


    }


}