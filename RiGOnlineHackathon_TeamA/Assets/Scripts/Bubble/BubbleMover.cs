using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BubbleMover : MonoBehaviour
{
    [SerializeField] private InputProvider inputProvider;
    [SerializeField] private WindCreater windCreater;
    [SerializeField] private float movePower;

    private Transform bubbleTrans;
    private Rigidbody2D rb;
    private SEPlayer sePlayer;

    private bool startsMove;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        bubbleTrans = GetComponent<Transform>();
        sePlayer = GetComponent<SEPlayer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (startsMove)
        {
            if (inputProvider.isLeftMouseButtonDown)
            {
                Vector2 dir = ((Vector2)bubbleTrans.position - inputProvider.mousePos).normalized;
                sePlayer.PlaySE("Move");
                windCreater.CreateWind(inputProvider.mousePos, dir);
                MoveBubble(dir, movePower * 100);
            }
        }
    }

    public void StartMove(float startPower,float mass)
    {
        rb.constraints = RigidbodyConstraints2D.FreezeRotation;
        rb.AddForce(Vector2.right * startPower, ForceMode2D.Impulse);
        rb.mass = mass;
        startsMove = true;
    }

    public void MoveBubble(Vector2 direction, float movePower)
    {
        rb.AddForce(direction * movePower);
    }
}
