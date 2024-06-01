using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BowlingSceneController : MonoBehaviour
{
    private int obstaclesIndex = -1;
    public bool isTutorialShown = true;
    public bool hasBallCollided = false;

    [SerializeField] private BallController ball;
    [SerializeField] private BallController head;
    [SerializeField] private GameObject tutorialCanvas;
    [SerializeField] private GameObject[] obstaclesRounds;

    void Start()
    {
        tutorialCanvas.SetActive(true);
        foreach (GameObject obstacles in obstaclesRounds)
        {
            obstacles.SetActive(false);
        }
    }

    void Update()
    {
        StoryStages currentStage = GameState.StoryStage;
        if (currentStage == StoryStages.Round3) obstaclesIndex = 0;
        if (currentStage == StoryStages.Round4) obstaclesIndex = 1;
        if (currentStage == StoryStages.Round5) obstaclesIndex = 2;
        if (currentStage == StoryStages.Round6) obstaclesIndex = 3;
        if (currentStage == StoryStages.Round7) obstaclesIndex = 4;
        if (currentStage == StoryStages.Round8) obstaclesIndex = 5;
        if (currentStage >= StoryStages.Round9) obstaclesIndex = 6;

        for (int i = 0; i < obstaclesRounds.Length; i++)
        {
            if (i == obstaclesIndex) obstaclesRounds[i].SetActive(true);
            else obstaclesRounds[i].SetActive(false);
        }
    }

    public void OnThrowEnd()
    {
        hasBallCollided = false;
        if (GameState.StoryStage >= StoryStages.Round9) head.ResetPosition();
        else ball.ResetPosition();
    }
}
