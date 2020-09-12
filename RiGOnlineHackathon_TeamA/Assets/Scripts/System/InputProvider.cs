using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputProvider : MonoBehaviour
{
    public bool isLeftMouseButtonDown;
    public bool isLeftMouseButtonUp;
    public Vector2 mousePos;

    [SerializeField] private float nextCanClickTime;

    private bool isClick;
    private bool canClick = true;
    private float clickTimer;

    public void MainInput()
    {
        isLeftMouseButtonUp = Input.GetButtonUp("LeftMouseClick");
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        if (canClick)
        {
            isLeftMouseButtonDown = Input.GetButtonDown("LeftMouseClick");

            if (isLeftMouseButtonDown)
            {
                clickTimer = 0;
                canClick = false;
            }
        }
        else
        {
            isLeftMouseButtonDown = false;

            if (clickTimer >= nextCanClickTime)
            {
                canClick = true;
            }
            else
            {
                clickTimer += Time.deltaTime;
            }
        }
    }

    public bool GetSkipButtonDown()
    {
        return Input.GetButtonDown("LeftMouseClick");
    }
}
