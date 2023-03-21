using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    public Vector2 turn;
    public float baseSpeed = 0.2f;
    public float sprintSpeed = 1f;
    public float currentSpeed;
    public GameObject player;
    //private Rigidbody rb;
    bool collision;

    [SerializeField] Transform cam;

    void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        //rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.LeftShift))
        {
            currentSpeed = baseSpeed + sprintSpeed;
        }

        else
        {
            currentSpeed = baseSpeed;
        }

        //Vector3 move = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));

        float playerVertInput = Input.GetAxis("Vertical") * Time.deltaTime * currentSpeed;
        float playerHoriInput = Input.GetAxis("Horizontal") * Time.deltaTime * currentSpeed;

        //Vector3 move = new Vector3(playerHoriInput, playerVertInput, 0);

        //characterController.Move(move*Time.deltaTime * speed);

        Vector3 camForward = cam.forward;
        Vector3 camRight = cam.right;

        camForward.y = 0;
        camRight.y = 0;

        camForward = camForward.normalized;
        camRight = camRight.normalized;

        Vector3 forwardRelative = playerVertInput * camForward;
        Vector3 rightRelative = playerHoriInput * camRight;

        Vector3 camRelative = forwardRelative + rightRelative;

        turn.x += Input.GetAxis("Mouse X");
        turn.y += Input.GetAxis("Mouse Y");
        //float y = Input.GetAxis("Mouse X") * turnSpeed;
        //player.transform.eulerAngles = new Vector3(0, player.transform.eulerAngles.y + y, 0);
        transform.localRotation = Quaternion.Euler(-turn.y, turn.x, 0);

        //collision detection w/ conditional movement
        Ray ray = new Ray(transform.position, transform.forward);

        if (Physics.Raycast(ray, 0.3f + currentSpeed * Time.deltaTime))
        {
            collision = true;
        }
        else collision = false;

        if (!collision)
        {
            transform.Translate(camRelative, Space.World);
        }
    }
}
