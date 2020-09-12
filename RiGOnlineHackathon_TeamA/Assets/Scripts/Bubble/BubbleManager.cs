using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BubbleManager : MonoBehaviour
{
    public GameObject bubble;
    [HideInInspector] public BubbleCore bubbleCore;

    // Start is called before the first frame update
    void Start()
    {
        bubbleCore = bubble.GetComponent<BubbleCore>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
