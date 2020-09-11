using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum GameState
{
    START,
    CREATE,
    MAIN,
    FINISH
}

public class Course1MainSystem : MonoBehaviour
{
    [SerializeField] private GameState gameState;

    [Header("Create")]
    [SerializeField] private BubbleCreater bubbleCreater;

    [Header("Main")]
    [SerializeField] private BubbleManager bubbleManager;

    InputProvider inputProvider;

    private void Awake()
    {
        inputProvider = GetComponent<InputProvider>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        switch (gameState)
        {
            case GameState.START:
                break;
            case GameState.CREATE:
                inputProvider.MainInput();

                if (bubbleCreater.finishesBubbleCreate)
                {
                    gameState = GameState.MAIN;
                }

                break;
            case GameState.MAIN:
                inputProvider.MainInput();

                if (bubbleManager.bubbleCore.isHit)
                {
                    gameState = GameState.FINISH;
                }

                break;
            case GameState.FINISH:
                break;
        }
    }
}
