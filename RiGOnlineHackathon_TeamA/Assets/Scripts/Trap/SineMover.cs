using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class SineMover : MonoBehaviour
{
    [SerializeField, Tooltip("X軸の速度")] private float xMoveSpeed;
    [SerializeField, Tooltip("Y軸の最高速度")] private float maxYMoveSpeed;
    [SerializeField, Tooltip("周期")] private float period;

    private Rigidbody2D rb;
    private Transform trapTras;
    private bool isSpeedPositive;

    private void Awake()
    {
        trapTras = GetComponent<Transform>();
        rb = GetComponent<Rigidbody2D>();
    }

    // Start is called before the first frame update
    void Start()
    {
        rb.velocity = Vector2.up * maxYMoveSpeed;
        isSpeedPositive = true;
    }

    private void FixedUpdate()
    {
        rb.velocity = (Vector2)trapTras.right * xMoveSpeed + Vector2.up * rb.velocity.y;

        if (isSpeedPositive)
        {
            if (rb.velocity.y > -maxYMoveSpeed)
            {
                rb.velocity -= (maxYMoveSpeed / period) * Vector2.up * Time.fixedDeltaTime;
            }
            else
            {
                isSpeedPositive = false;
            }
        }
        else
        {
            if (rb.velocity.y < maxYMoveSpeed)
            {
                rb.velocity += (maxYMoveSpeed / period) * Vector2.up * Time.fixedDeltaTime;
            }
            else
            {
                isSpeedPositive = true;
            }
        }
    }
}
