using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BubbleCreateUIDrawer : MonoBehaviour
{
    [SerializeField] private BubbleCreater bubbleCreater;
    private Slider slider;

    private void Awake()
    {
        slider = GetComponent<Slider>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        slider.value = (bubbleCreater.nowSize - bubbleCreater.minSize) / (bubbleCreater.maxSize - bubbleCreater.minSize);
    }
}
