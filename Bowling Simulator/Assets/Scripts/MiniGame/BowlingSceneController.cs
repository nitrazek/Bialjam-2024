using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BowlingSceneController : MonoBehaviour
{
    [SerializeField] private BallController ball;

    public void OnThrowEnd()
    {
        ball.Reset();
    }
}
