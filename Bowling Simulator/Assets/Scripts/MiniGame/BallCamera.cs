using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallCamera : MonoBehaviour
{
    private Vector3 offset;

    [SerializeField] private Transform target;

    private void Awake()
    {
        offset = transform.position - target.position;
    }

    private void LateUpdate()
    {
        Vector3 targetPosition = target.position + offset;
        transform.position = targetPosition;
    }
}
