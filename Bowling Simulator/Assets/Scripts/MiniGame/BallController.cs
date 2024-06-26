using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    private Vector3 checkpoint;
    private Quaternion initialRotation;

    private float verticalSpeed = 45f;
   
    private float horizontal;
    private float horizontalSpeed = 5f;

    private float width = 5f;
    private float widthPosition = 0f;
    private float widthVelocity = 0.1f;
    private float widthDirection = 1f;

    private bool isMoving = false;

    [SerializeField] private Rigidbody rb;
    [SerializeField] private TutorialController tutorial;
    [SerializeField] private GameObject directionArrow;

    void Awake()
    {
        checkpoint = transform.position;
        initialRotation = transform.rotation;
        ResetPosition();

        if (gameObject.name == "head")
        {
            gameObject.SetActive(false);
        }
    }

    void Update()
    {
        if (tutorial.IsActive()) return;

        horizontal = Input.GetAxisRaw("Horizontal");
        if (Input.GetKey(KeyCode.Space) && !isMoving)
        {
            isMoving = true;
            rb.AddForce(new Vector3(widthDirection * horizontalSpeed * Random.value, 0, verticalSpeed), ForceMode.VelocityChange);
        }

        if (isMoving) directionArrow.SetActive(false);
        else directionArrow.SetActive(true);
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
            rb.AddForce(new Vector3(horizontal * horizontalSpeed, 0, 0), ForceMode.Acceleration);
        }
    }

    public void ResetPosition()
    {
        Debug.Log(gameObject.name + " " + transform.position);
        transform.position = checkpoint;
        transform.rotation = initialRotation;
        rb.velocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;
        isMoving = false;
        directionArrow.SetActive(false);
        widthPosition = 0f;
    }
}
