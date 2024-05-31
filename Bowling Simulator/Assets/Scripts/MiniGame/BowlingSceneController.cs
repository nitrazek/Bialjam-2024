using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BowlingSceneController : MonoBehaviour
{
    private GameObject currentObstacles;
    public bool isTutorialShown = true;
    public bool hasBallCollided = false;

    [SerializeField] private BallController ball;
    [SerializeField] private GameObject tutorialCanvas;
    [SerializeField] private GameObject obstacles_round3;
    [SerializeField] private GameObject obstacles_round4;
    [SerializeField] private GameObject obstacles_round5;

    void Start()
    {
        tutorialCanvas.SetActive(true);
        currentObstacles = null;
        obstacles_round3.SetActive(false);
        obstacles_round4.SetActive(false);
        obstacles_round5.SetActive(false);
    }

    void Update()
    {
        if (GameState.StoryStage == StoryStages.Round3) currentObstacles = obstacles_round3;
        else if (GameState.StoryStage == StoryStages.Round4) currentObstacles = obstacles_round4;
        else if (GameState.StoryStage >= StoryStages.Round5) currentObstacles = obstacles_round5;

        if (currentObstacles != null) currentObstacles.SetActive(true);
    }

    public void OnThrowEnd()
    {
        hasBallCollided = false;
        ball.Reset();
    }
}
