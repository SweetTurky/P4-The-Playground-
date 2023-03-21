using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    public Vector2 turn;
    public float baseSpeed = 0.2f;
    public float sprintSpeed = 1f;
    public float currentSpeed;
    public GameObject player;
    private Rigidbody rb;
    public Transform cam;

    void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        rb = this.GetComponent<Rigidbody>();
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

        Vector3 camRelativeMove = forwardRelative + rightRelative;
        
        Vector3 velocity = camRelativeMove * currentSpeed * Time.fixedDeltaTime;
        rb.velocity = velocity;

        turn.x += Input.GetAxis("Mouse X");
        turn.y += Input.GetAxis("Mouse Y");
        transform.localRotation = Quaternion.Euler(-turn.y, turn.x, 0);

        //collision detection w/ conditional movement

        /*Ray ray = new Ray(transform.position, transform.forward);

        if (Physics.Raycast(ray, 0.3f + currentSpeed * Time.deltaTime))
        {
            collision = true;
        }
        else collision = false;

        if (!collision)
        {
            transform.Translate(camRelative, Space.World);
        }*/
    }
}
