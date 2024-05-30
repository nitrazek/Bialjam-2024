using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    private float verticalSpeed = 45f;
   
    private float horizontal;
    private float horizontalSpeed = 10f;

    private float width = 5f;
    private float widthPosition = 0f;
    private float widthVelocity = 0.1f;
    private float widthDirection = 1f;
    
    private bool isMoving = false;

    [SerializeField] private Rigidbody rb;

    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        if (Input.GetKey(KeyCode.Space) && !isMoving)
        {
            isMoving = true;
            rb.AddForce(new Vector3(0, 0, verticalSpeed), ForceMode.VelocityChange);
        }
    }

    private void FixedUpdate()
    {
        if (!isMoving)
        {
            if (widthPosition >= width / 2) widthDirection = -1f;
            else if (widthPosition <= (width / 2) * -1) widthDirection = 1f;
            
            rb.position = new Vector3(rb.position.x + (widthDirection * widthVelocity), rb.position.y, rb.position.z);
            widthPosition += widthDirection * widthVelocity;
        }
        else
        {
            rb.AddForce(new Vector3(horizontal * horizontalSpeed, 0, 0));
        }
    }
}
