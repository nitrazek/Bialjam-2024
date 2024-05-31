using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BowlingSceneController : MonoBehaviour
{
    public bool isTutorialShown = true;

    [SerializeField] private BallController ball;
    [SerializeField] private GameObject tutorialCanvas;

    void Start()
    {
        tutorialCanvas.SetActive(true);
    }

    public void OnThrowEnd()
    {
        ball.Reset();
    }
}
