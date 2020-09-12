using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapReleaser : MonoBehaviour
{
    [SerializeField] private Transform bubbleTrans;
    [SerializeField] private Sprite[] sprites;
    [SerializeField] private float createInterval;
    [SerializeField] private float stopDistance;

    private ObjectPool objectPool;
    private Transform trapReleaseTrans;

    private IEnumerator corutine;

    private void Awake()
    {
        objectPool = GetComponent<ObjectPool>();
        trapReleaseTrans = GetComponent<Transform>();
    }

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(RepeatCreate());
    }

    private void Update()
    {
        float nowDistance = Mathf.Abs(bubbleTrans.position.x - trapReleaseTrans.position.x);

        if(nowDistance <= stopDistance)
        {
            StopCoroutine(RepeatCreate());
        }
    }

    private IEnumerator RepeatCreate()
    {
        while (true)
        {
            CreateTrap();

            yield return new WaitForSeconds(createInterval);
        }
    }

    private void CreateTrap()
    {
        int spriteNum = Random.Range(0, sprites.Length);

        GameObject trapObj = objectPool.GetObject();
        trapObj.transform.position = trapReleaseTrans.position;
        trapObj.GetComponent<SpriteRenderer>().sprite = sprites[spriteNum];
    }
}
