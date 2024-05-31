using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallEndCollider : MonoBehaviour
{
    [SerializeField] BowlingMinigameController controller;
    [SerializeField] BowlingSceneController sceneController;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Ball")
        {
            controller.OnThrowEnd();
            sceneController.OnThrowEnd();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Ball")
            StartCoroutine(RestartBallWithDelay());
    }

    private IEnumerator RestartBallWithDelay()
    {
        yield return new WaitForSeconds(0.5f);
        controller.OnThrowEnd();
        sceneController.OnThrowEnd();
        yield return null;
    }
}
