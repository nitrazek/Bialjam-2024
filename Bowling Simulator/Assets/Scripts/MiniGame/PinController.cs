using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PinController : MonoBehaviour
{
    private Vector3 checkpoint;
    private Quaternion initialRotation;
    private bool isKnockedOver = false;

    [SerializeField] private Rigidbody rb;
    [SerializeField] private float knockOverThreshold = 10f;
    [SerializeField] private BowlingMinigameController bowlingMinigameController;

    void Start()
    {
        checkpoint = transform.position;
        initialRotation = transform.rotation;
        Reset();
    }

    void Update()
    {
        float angle = Vector3.Angle(transform.forward, Vector3.up);
        if (!isKnockedOver && angle > knockOverThreshold)
        {
            isKnockedOver = true;
            bowlingMinigameController.OnPinKnockedOver();
        }
    }

    public void Reset()
    {
        transform.position = checkpoint;
        transform.rotation = initialRotation;
        rb.velocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;
    }
}
