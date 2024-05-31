using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallCameraFreeze : MonoBehaviour
{
    [SerializeField] private BallCamera ballCamera;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Ball")
        {
            ballCamera.OnFreeze();
        }
    }
}
