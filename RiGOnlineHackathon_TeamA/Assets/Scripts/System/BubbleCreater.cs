﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BubbleCreater : MonoBehaviour
{
    [SerializeField, Tooltip("泡のオブジェクト")] private GameObject bubbleObj;
    [SerializeField, Tooltip("膨らむ場所")] private Transform nozzleTrans;
    [SerializeField] InputProvider inputProvider;
    [Header("サイズ")]
    [SerializeField,Tooltip("最大サイズ")] private float maxSize;
    [SerializeField,Tooltip("最小サイズ")] private float minSize;
    [Header("重量")]
    [SerializeField, Tooltip("最大重量")] private float maxMass;
    [SerializeField, Tooltip("最小重量")] private float minMass;
    [Header("膨らむ")]
    [SerializeField,Tooltip("1秒間に膨らむサイズ")] private float expandSpeed;
    [SerializeField, Tooltip("1秒間に右に移動する距離")] private float expandRightMoveSpeed;
    [Header("放出")]
    public bool finishesBubbleCreate;
    [SerializeField,Tooltip("放出する力")] private float releasePower;

    private Transform bubbleTrans;
    private BubbleMover bubbleMover;

    private bool isBubbleCreate;
    private bool onceBubbleStart;

    private float nowSize;

    private void Awake()
    {

    }
    // Start is called before the first frame update
    void Start()
    {
        bubbleTrans = bubbleObj.GetComponent<Transform>();
        bubbleMover = bubbleObj.GetComponent<BubbleMover>();
    }

    // Update is called once per frame
    void Update()
    {

        if (!finishesBubbleCreate)
        {
            if (!isBubbleCreate)
            {
                if (inputProvider.isLeftMouseButtonDown)
                {
                    CreateBubble();
                    isBubbleCreate = true;
                }
            }
            else
            {
                nowSize += expandSpeed * Time.deltaTime;
                bubbleTrans.position += Vector3.right * (expandRightMoveSpeed * Time.deltaTime);

                if (nowSize >= maxSize)
                {
                    nowSize = maxSize;
                    finishesBubbleCreate = true;
                }

                bubbleTrans.localScale = new Vector3(nowSize, nowSize, 1);

                if (inputProvider.isLeftMouseButtonUp)
                {
                    finishesBubbleCreate = true;
                }
            }
        }
        else
        {
            if (!onceBubbleStart)
            {
                float bubbleMass = CalcSizeToMass();
                bubbleMover.StartMove(releasePower,bubbleMass);
                onceBubbleStart = true;
            }
        }
    }

    private void CreateBubble()
    {
        bubbleTrans.position = nozzleTrans.position;
        nowSize = minSize;
        bubbleTrans.localScale = new Vector3(nowSize, nowSize, 1);

        bubbleObj.SetActive(true);
    }

    private float CalcSizeToMass()
    {
        return minMass + ((maxMass - minMass) * ((nowSize - minSize) / (maxSize - minSize)));

    }
}
