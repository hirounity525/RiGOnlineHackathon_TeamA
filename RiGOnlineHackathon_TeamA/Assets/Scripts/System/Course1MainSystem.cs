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

    [Header("Start")]
    [SerializeField] private TimelineController startTimeline;

    [Header("Create")]
    [SerializeField] private BubbleCreater bubbleCreater;

    [Header("Main")]
    [SerializeField] private BubbleManager bubbleManager;
    [SerializeField] private GameObject uchiwaObj;

    [Header("Finish")]
    [SerializeField] private ScoreUIDrawer scoreUI;
    [SerializeField] private TimelineController scoreTimeline;
    [SerializeField] private float scoreSkipTime;

    private InputProvider inputProvider;
    private SEPlayer sePlayer;
    private SceneLoader sceneLoader;
    private ScoreManager scoreManager;

    private bool startsPlay;

    private bool startsScore;
    private bool isSkipScore;

    private void Awake()
    {
        inputProvider = GetComponent<InputProvider>();
        sePlayer = GetComponent<SEPlayer>();
        sceneLoader = GetComponent<SceneLoader>();
        scoreManager = GetComponent<ScoreManager>();
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

                if (!startsPlay)
                {
                    startTimeline.PlayTimeline();
                    startsPlay = true;
                }

                if (startTimeline.isFinish)
                {
                    gameState = GameState.CREATE;
                }

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

                if (!uchiwaObj.activeSelf) uchiwaObj.SetActive(true);

                if (bubbleManager.bubbleCore.isHit)
                {
                    scoreManager.isGameClear = false;
                    bubbleManager.StopBubble();
                    ScoreSave();
                    gameState = GameState.FINISH;
                }

                if (bubbleManager.bubbleCore.isGoal)
                {
                    scoreManager.isGameClear = true;
                    sePlayer.PlaySE("Goal");
                    ScoreSave();
                    gameState = GameState.FINISH;
                }

                break;
            case GameState.FINISH:

                if (!startsScore)
                {
                    scoreTimeline.PlayTimeline();
                    startsScore = true;
                }

                if(!isSkipScore && inputProvider.GetSkipButtonDown() && scoreTimeline.timelineTime() < scoreSkipTime)
                {
                    scoreTimeline.SkipTimeline(scoreSkipTime);
                    isSkipScore = true;
                }

                if (scoreTimeline.isFinish)
                {
                    sceneLoader.Load("Title");
                }

                break;
        }
    }

    private void ScoreSave()
    {
        scoreUI.flyingDistanceText.text = scoreManager.FlyingDistance().ToString();
        scoreUI.sizeText.text = scoreManager.SizePercent().ToString();
        if (scoreManager.isGameClear)
        {
            scoreUI.clearBonusText.text = "×" + scoreManager.clearBonusMultiple.ToString();
        }
        else
        {
            scoreUI.clearBonusText.text = "";
        }
        scoreUI.totalScoreText.text = scoreManager.TotalScore().ToString();
    }
}
