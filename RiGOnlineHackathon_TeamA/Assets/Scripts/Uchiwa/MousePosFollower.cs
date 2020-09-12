using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MousePosFollower : MonoBehaviour
{
    [SerializeField] private InputProvider inputProvider;

    Transform objTrans;

    private void Awake()
    {
        objTrans = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        objTrans.position = inputProvider.mousePos;
    }
}
