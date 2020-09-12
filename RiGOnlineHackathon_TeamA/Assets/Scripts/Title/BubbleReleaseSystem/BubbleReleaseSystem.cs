using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BubbleReleaseSystem : MonoBehaviour
{
    [SerializeField] private Sprite[] bubbleSprites;
    [SerializeField] private float nextReleaseTime;
    [SerializeField] private float maxReleaseRadius;
    [SerializeField] private int minSpeed;
    [SerializeField] private int maxSpeed;
    [SerializeField] private float minSize;
    [SerializeField] private float maxSize;

    private ObjectPool objectPool;
    private Transform systemTrans;

    private void Awake()
    {
        objectPool = GetComponent<ObjectPool>();
        systemTrans = GetComponent<Transform>();
    }

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(ReleaseBubble());
    }

    private IEnumerator ReleaseBubble()
    {
        while (true)
        {
            CreateBubble();

            yield return new WaitForSeconds(nextReleaseTime);
        }
    }

    private void CreateBubble()
    {
        float bubblePosX = Random.Range(-maxReleaseRadius, maxReleaseRadius);
        int bubbleSpriteNum = Random.Range(0, bubbleSprites.Length);
        int bubbleSpeed = Random.Range(minSpeed, maxSpeed);
        float bubbleSize = Random.Range(minSize, maxSize);

        GameObject bubble = objectPool.GetObject();
        bubble.transform.position = systemTrans.position + (Vector3.right * bubblePosX);
        bubble.transform.localScale = new Vector3(bubbleSize, bubbleSize, 1);
        bubble.GetComponent<SpriteRenderer>().sprite = bubbleSprites[bubbleSpriteNum];
        bubble.GetComponent<Rigidbody2D>().velocity = Vector2.up * bubbleSpeed;
    }
}
