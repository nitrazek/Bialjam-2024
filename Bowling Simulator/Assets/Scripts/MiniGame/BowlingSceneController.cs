using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BowlingSceneController : MonoBehaviour
{
    [SerializeField] private BallController ball;
    [SerializeField] private PinResetter pins;

    public void OnThrowEnd()
    {
        ball.Reset();
        pins.Reset();
    }
}
