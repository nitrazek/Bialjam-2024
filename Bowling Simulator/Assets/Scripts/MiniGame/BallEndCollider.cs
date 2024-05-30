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
}
