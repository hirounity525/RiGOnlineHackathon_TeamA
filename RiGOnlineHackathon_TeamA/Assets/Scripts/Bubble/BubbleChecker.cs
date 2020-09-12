using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BubbleChecker : MonoBehaviour
{
    BubbleCore bubbleCore;
    SimpleAnimation simpleAnimation;
    SEPlayer sePlayer;

    private void Awake()
    {
        bubbleCore = GetComponent<BubbleCore>();
        simpleAnimation = GetComponent<SimpleAnimation>();
        sePlayer = GetComponent<SEPlayer>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!bubbleCore.isHit)
        {
            if (collision.gameObject.tag == "Trap")
            {
                simpleAnimation.Play("Break");
                sePlayer.PlaySE("Break");
                bubbleCore.isHit = true;
            }
        }
    }
}
