using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PushPullMover : MonoBehaviour
{
    [SerializeField, Tooltip("どこまで押すか")] private float pushPosition;
    [SerializeField, Tooltip("押す速度")] private float pushSpeed;
    [SerializeField, Tooltip("押してから引くまでの時間")] private float pullInterval;
    [SerializeField, Tooltip("引く速度")] private float pullSpeed;
    [SerializeField, Tooltip("引いてから押すまでの時間")] private float pushInterval;

    private Rigidbody2D rb;
    private Transform trapTrans;

    private Vector3 firstPos;
    private bool isPush;
    private bool isPull;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        trapTrans = GetComponent<Transform>();
    }

    // Start is called before the first frame update
    void Start()
    {
        Vector3 newVec = trapTrans.position;
        firstPos = newVec;

        StartCoroutine(PullCoroutine());
    }
    private void FixedUpdate()
    {
        if (isPush)
        {
            rb.velocity = trapTrans.up * pushSpeed;
            if (((firstPos + trapTrans.up * pushPosition) - trapTrans.position).magnitude <= 0.5f)
            {
                rb.velocity = Vector3.zero;
                isPush = false;
                StartCoroutine(PushCoroutine());
            }
        }

        if (isPull)
        {
            rb.velocity = -trapTrans.up * pullSpeed;
            if ((trapTrans.position - firstPos).magnitude <= 0.5f)
            {
                rb.velocity = Vector3.zero;
                isPull = false;
                StartCoroutine(PullCoroutine());
            }
        }
    }

    private IEnumerator PushCoroutine()
    {
        yield return new WaitForSeconds(pullInterval);

        isPull = true;
    }

    private IEnumerator PullCoroutine()
    {
        yield return new WaitForSeconds(pushInterval);

        isPush = true;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;

        Gizmos.DrawLine(transform.position, transform.position + (transform.up * pushPosition));
    }
}
