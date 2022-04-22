using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mov : MonoBehaviour
{


    public float Speed;
    public Rigidbody rb;

    public float maxSpeed;
    public float curMaxSpeed;
    private bool walking = true;

    public bool isGrounded;
    public Vector3 jump;
    public int jumps;

    public float gravity;
    public float jumpforce;
    public float groundDrag;
    public float PlayerHeight;

    float horizontalInput;
    float verticalInput;

    public Transform orientation;
    public Vector3 moveDirection;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        jump = new Vector3(0.0f, 2.0f, 0.0f);
        orientation = rb.transform;
    }

    void OnCollisionStay(Collision other)
    {
        isGrounded = true;
    }

    private void OnCollisionExit(Collision collision)
    {
        isGrounded = false;
        jumps = 1;
    }

    // Update is called once per frame
    void Update()
    {
        PlayerInput();
        PlayerSpeed();

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded || Input.GetKeyDown(KeyCode.Space) && jumps > 0)
        {

            rb.AddForce(jump * jumpforce, ForceMode.Impulse);
            isGrounded = false;
            jumps--;
        }

        if (isGrounded)
            rb.drag = groundDrag;
        else
            rb.drag = 0;

    }

    void PlayerInput()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");
    }

    private void FixedUpdate()
    {
        MovePlayer();

    }
    public void PlayerSpeed()
    {
        if (rb.velocity.magnitude > curMaxSpeed)
        {
            rb.velocity = Vector3.ClampMagnitude(rb.velocity, curMaxSpeed);
        }

        if (Input.GetKey(KeyCode.LeftShift))
        {
            walking = false;
            curMaxSpeed = maxSpeed * 2;
        } else
        {
            walking = true;
            curMaxSpeed = maxSpeed;
        }
    }

    public void MovePlayer()
    {
        moveDirection = orientation.forward * verticalInput + orientation.right * horizontalInput;
        if (!walking)
        {
            Speed = Speed * 2;
        }
        if (Input.GetKey(KeyCode.W) && isGrounded)
        {
            rb.AddForce(10f * Speed * moveDirection.normalized, ForceMode.Force);
        }
        else if (Input.GetKey(KeyCode.S) && isGrounded || Input.GetKey(KeyCode.D) && isGrounded || Input.GetKey(KeyCode.A) && isGrounded)
        {
            rb.AddForce(10f * (Speed - 1f) * moveDirection.normalized, ForceMode.Force);
        }
        else if (isGrounded)
        {
            rb.velocity = new Vector3(0, (rb.velocity.y), 0);
        }
        else if (!isGrounded)
        {
            rb.AddForce(10f * (Speed /6) * moveDirection.normalized, ForceMode.Force);
        }
        if (!walking)
        {
            Speed = Speed / 2;
        }
        Debug.Log(isGrounded);

    }

}
