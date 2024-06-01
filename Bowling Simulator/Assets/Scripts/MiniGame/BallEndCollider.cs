using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallEndCollider : MonoBehaviour
{
    [SerializeField] private BowlingMinigameController controller;
    [SerializeField] private BowlingSceneController sceneController;
    [SerializeField] private BallCamera ballCamera;

    private void OnTriggerEnter(Collider other)
    {
        if (!sceneController.hasBallCollided && other.gameObject.tag == "Ball")
        {
            sceneController.hasBallCollided = true;
            ballCamera.OnStopFreeze();
            controller.OnThrowEnd();
            sceneController.OnThrowEnd();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (!sceneController.hasBallCollided && collision.gameObject.tag == "Ball")
        {
            sceneController.hasBallCollided = true;
            StartCoroutine(RestartBallWithDelay());
        }
    }

    private IEnumerator RestartBallWithDelay()
    {
        yield return new WaitForSeconds(0.15f);
        ballCamera.OnStopFreeze();
        sceneController.OnThrowEnd();
        //controller.OnThrowEnd();
        yield return null;
    }
}
