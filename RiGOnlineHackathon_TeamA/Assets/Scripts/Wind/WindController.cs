using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindController : MonoBehaviour
{
    private SimpleAnimation simpleAnimation;

    private void Awake()
    {
        simpleAnimation = GetComponent<SimpleAnimation>();
    }

    private void OnEnable()
    {
        simpleAnimation.Play("Wind");
    }

    public void Destroy()
    {
        gameObject.SetActive(false);
    }
}
