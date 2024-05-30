using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PinController : MonoBehaviour
{
    private bool isKnockedOver = false;

    [SerializeField] private float knockOverThreshold = 10f;
    [SerializeField] private BowlingMinigameController bowlingMinigameController;

    void Update()
    {
        float angle = Vector3.Angle(transform.forward, Vector3.up);
        if (!isKnockedOver && angle > knockOverThreshold)
        {
            isKnockedOver = true;
            bowlingMinigameController.OnPinKnockedOver();
        }
    }
}
