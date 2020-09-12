using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DistanceUIDrawer : MonoBehaviour
{
    [SerializeField] private Transform bubbleTrans;
    [SerializeField] private Transform startTrans;
    [SerializeField] private Transform goalTrans;

    private Slider slider;

    private void Awake()
    {
        slider = GetComponent<Slider>();
    }

    // Update is called once per frame
    void Update()
    {
        slider.value = (bubbleTrans.position.x - startTrans.position.x) / (goalTrans.position.x - startTrans.position.x);
    }
}
