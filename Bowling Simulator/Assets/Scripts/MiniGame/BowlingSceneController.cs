using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BowlingSceneController : MonoBehaviour
{
    public bool isTutorialShown = true;

    [SerializeField] private BallController ball;
    [SerializeField] private GameObject tutorialCanvas;
    [SerializeField] private GameObject beavers;

    void Start()
    {
        tutorialCanvas.SetActive(true);
        beavers.SetActive(false);
    }

    void Update()
    {
        if(GameState.StoryStage == StoryStages.Round3)
        {
            beavers.SetActive(true);
        }
    }

    public void OnThrowEnd()
    {
        ball.Reset();
    }
}
