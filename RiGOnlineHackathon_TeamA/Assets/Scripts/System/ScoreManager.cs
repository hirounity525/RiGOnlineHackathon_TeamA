using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    [SerializeField] private Transform bubbleTrans;
    [SerializeField] private Transform startTrans;
    [SerializeField] private Transform goalTrans;
    [SerializeField] private BubbleCreater bubbleCreater;

    public bool isGameClear;
    public int clearBonusMultiple;

    public int FlyingDistance()
    {
        int distance = (int)(bubbleTrans.position.x - startTrans.position.x);
        if(distance >= goalTrans.position.x)
        {
            distance = (int)(goalTrans.position.x);
        }
        return distance;
    }

    public int SizePercent()
    {
        int percent = (int)(((bubbleCreater.nowSize - bubbleCreater.minSize) / (bubbleCreater.maxSize - bubbleCreater.minSize)) * 100);
        if(percent >= 100)
        {
            percent = 100;
        }
        return percent;
    }

    public int TotalScore()
    {
        if (isGameClear)
        {
            return FlyingDistance() * SizePercent() * clearBonusMultiple;
        }
        else
        {
            return FlyingDistance() * SizePercent() * 1;
        }
    }

}
