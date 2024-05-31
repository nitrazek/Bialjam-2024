using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallCamera : MonoBehaviour
{
    private Vector3 offset;
    private bool isFrozen = false;

    [SerializeField] private Transform target;

    private void Awake()
    {
        offset = transform.position - target.position;
    }

    private void LateUpdate()
    {
        if (!isFrozen) transform.position = new Vector3(transform.position.x, transform.position.y, target.position.z + offset.z);
    }

    public void OnFreeze()
    {
        isFrozen = true;
    }

    public void OnStopFreeze()
    {
        isFrozen = false;
    }
}
