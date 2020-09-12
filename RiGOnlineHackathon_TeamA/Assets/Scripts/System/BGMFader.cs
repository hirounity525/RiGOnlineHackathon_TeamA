using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGMFader : MonoBehaviour
{
    [SerializeField] private Transform bubbleTrans;
    [SerializeField] private AudioSource beforeAudioSource;
    [SerializeField] private AudioSource afterAudioSource;
    [SerializeField] private float fadeDistance;

    private Transform fadeTrans;

    private void Awake()
    {
        fadeTrans = GetComponent<Transform>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float distance = bubbleTrans.position.x - fadeTrans.position.x;

        if(Mathf.Abs(distance) <= fadeDistance)
        {
            beforeAudioSource.volume = 1 - ((distance + fadeDistance) / (fadeDistance + fadeDistance));
            afterAudioSource.volume = ((distance + fadeDistance) / (fadeDistance + fadeDistance));
        }
    }
}
