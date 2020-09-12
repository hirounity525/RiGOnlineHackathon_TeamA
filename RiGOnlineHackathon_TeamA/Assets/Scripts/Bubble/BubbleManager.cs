using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BubbleManager : MonoBehaviour
{
    public GameObject bubble;
    [HideInInspector] public BubbleCore bubbleCore;
    private Rigidbody2D bubbleRb;

    // Start is called before the first frame update
    void Start()
    {
        bubbleCore = bubble.GetComponent<BubbleCore>();
        bubbleRb = bubble.GetComponent<Rigidbody2D>();
    }

    public void StopBubble()
    {
        bubbleRb.constraints = RigidbodyConstraints2D.FreezeAll;
    }
}
