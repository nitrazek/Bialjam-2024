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
    [SerializeField] private GameObject obstacles_round6;
    [SerializeField] private GameObject obstacles_round7;
    [SerializeField] private GameObject obstacles_round8;

    void Start()
    {
        tutorialCanvas.SetActive(true);
        currentObstacles = null;
        obstacles_round3.SetActive(false);
        obstacles_round4.SetActive(false);
        obstacles_round5.SetActive(false);
        obstacles_round6.SetActive(false);
        obstacles_round7.SetActive(false);
        obstacles_round8.SetActive(false);
    }

    void Update()
    {
        if (GameState.StoryStage == StoryStages.Round3) currentObstacles = obstacles_round3;
        else if (GameState.StoryStage == StoryStages.Round4) currentObstacles = obstacles_round4;
        else if (GameState.StoryStage == StoryStages.Round5) currentObstacles = obstacles_round5;
        else if (GameState.StoryStage == StoryStages.Round6) currentObstacles = obstacles_round6;
        else if (GameState.StoryStage == StoryStages.Round7) currentObstacles = obstacles_round7;
        else if (GameState.StoryStage >= StoryStages.Round8) currentObstacles = obstacles_round8;

        if (currentObstacles != null) currentObstacles.SetActive(true);
    }

    public void OnThrowEnd()
    {
        hasBallCollided = false;
        ball.Reset();
    }
}
