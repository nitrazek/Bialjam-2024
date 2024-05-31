using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BowlingSceneController : MonoBehaviour
{
    public bool isTutorialShown = true;

    [SerializeField] private BallController ball;
    [SerializeField] private PinResetter pins;

    public void OnThrowEnd()
    {
        ball.Reset();
        pins.Reset();
    }
}
