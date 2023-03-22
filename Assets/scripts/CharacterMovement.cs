using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CharacterMovement : MonoBehaviour
{
    public Vector2 turn;
    public float baseSpeed = 0.2f;
    public float sprintSpeed = 1f;
    public float currentSpeed;
    //public int jumpHeight;
    //public bool grounded = false;

    public GameObject player;
    private Rigidbody rb;
    public Transform cam;


    void Awake()
    {
        rb = this.GetComponent<Rigidbody>();
    }

    void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.LeftShift))
        {
            currentSpeed = baseSpeed + sprintSpeed;
        }

        else
        {
            currentSpeed = baseSpeed;
        }

        float playerVertInput = Input.GetAxis("Vertical");
        float playerHoriInput = Input.GetAxis("Horizontal");

        Vector3 camForward = cam.forward;
        Vector3 camRight = cam.right;

        camForward.y = 0;
        camRight.y = 0;

        camForward = camForward.normalized;
        camRight = camRight.normalized;

        Vector3 forwardRelative = playerVertInput * camForward;
        Vector3 rightRelative = playerHoriInput * camRight;

        Vector3 camRelativeMove = forwardRelative + rightRelative;
        
        Vector3 velocity = camRelativeMove * currentSpeed * Time.fixedDeltaTime;
        rb.velocity = velocity;

        turn.x += Input.GetAxisRaw("Mouse X");
        turn.y += Input.GetAxisRaw("Mouse Y");
        transform.rotation = Quaternion.Euler(-turn.y, turn.x, 0);
        
        /*if (Input.GetKeyDown(KeyCode.Space)
        {
            rb.AddForce(Vector3.up * jumpHeight, ForceMode.Impulse);
        } */
    }
}
