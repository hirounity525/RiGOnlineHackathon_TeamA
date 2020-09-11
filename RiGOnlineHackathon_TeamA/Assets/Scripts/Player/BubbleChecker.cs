using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BubbleChecker : MonoBehaviour
{
    BubbleCore bubbleCore;

    private void Awake()
    {
        bubbleCore = GetComponent<BubbleCore>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        bubbleCore.isHit = true;
    }
}
