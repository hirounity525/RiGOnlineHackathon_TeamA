using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManualController : MonoBehaviour
{
    SimpleAnimation simpleAnimation;

    private void Awake()
    {
        simpleAnimation = GetComponent<SimpleAnimation>();
    }

    public void StartClose()
    {
        simpleAnimation.Play("Close");
    }

    public void Close()
    {
        gameObject.SetActive(false);
    }
}
