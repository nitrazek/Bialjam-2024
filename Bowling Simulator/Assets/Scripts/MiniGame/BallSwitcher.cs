using System.Collections;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using UnityEngine;

public class BallSwitcher : MonoBehaviour
{
    [SerializeField] private GameObject ball;
    [SerializeField] private GameObject head;

    void Update()
    {
        if (GameState.StoryStage >= StoryStages.Round9)
        {
            ball.SetActive(false);
            head.SetActive(true);
            return;
        }
        ball.SetActive(true);
        head.SetActive(false);
    }
}
