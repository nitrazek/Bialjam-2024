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
        //transform.position = target.position + offset;
        transform.position = new Vector3(transform.position.x, transform.position.y, target.position.z + offset.z);
    }
}
