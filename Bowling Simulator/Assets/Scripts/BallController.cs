using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    private float horizontalSpeed = 5f;
    private float verticalSpeed = 8f;
    private float horizontal;
    private bool isMoving = false;

    [SerializeField] private Rigidbody rb;

    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        if (Input.GetKey(KeyCode.Space))
        {
            isMoving = true;
            rb.velocity = Vector3.zero;
            rb.AddForce(new Vector3(0, 0, verticalSpeed), ForceMode.VelocityChange);
        }
    }

    private void FixedUpdate()
    {
        if (!isMoving)
        {
            rb.position = new Vector3(rb.position.x + horizontal * 0.1f, rb.position.y, rb.position.z);
        }
        else
        {
            rb.AddForce(new Vector3(horizontal * horizontalSpeed, 0, 0));
        }
    }
}
