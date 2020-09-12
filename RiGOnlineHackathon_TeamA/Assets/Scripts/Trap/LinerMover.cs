using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class LinerMover : MonoBehaviour
{
    [SerializeField, Range(0, 360)] private int moveRadius;
    [SerializeField] private float moveSpeed;

    Rigidbody2D rb;
    Transform trapTrans;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        trapTrans = GetComponent<Transform>();
    }

    private void Start()
    {
        trapTrans.rotation = Quaternion.Euler(Vector3.forward * moveRadius);
    }

    private void FixedUpdate()
    {
        rb.velocity = trapTrans.up * moveSpeed;
    }
}
