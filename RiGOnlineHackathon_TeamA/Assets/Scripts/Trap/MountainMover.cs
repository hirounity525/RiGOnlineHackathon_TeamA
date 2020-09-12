using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class MountainMover : MonoBehaviour
{
    [SerializeField, Range(0, 360)] private int releaseRadius;
    [SerializeField] private float movePower;

    Rigidbody2D rb;
    Transform trapTrans;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        trapTrans = GetComponent<Transform>();
    }

    private void OnEnable()
    {
        trapTrans.rotation = Quaternion.Euler(Vector3.forward * releaseRadius);
        rb.AddForce(trapTrans.up * movePower, ForceMode2D.Impulse);
    }
}
