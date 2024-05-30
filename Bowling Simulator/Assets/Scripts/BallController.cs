using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    private float horizontalSpeed = 5f;
    private float verticalSpeed = 100f;
    private float horizontal;
    private bool isMoving = false;

    [SerializeField] private Rigidbody2D rb;

    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        if (Input.GetKey(KeyCode.Space))
        {
            isMoving = true;
            rb.velocity = new Vector2(0, 0);
            rb.AddForce(new Vector2(0, verticalSpeed));
        }
    }

    private void FixedUpdate()
    {
        if(!isMoving)
        {
            rb.velocity = new Vector2(horizontal * horizontalSpeed, rb.velocity.y);
        }
    }
}
