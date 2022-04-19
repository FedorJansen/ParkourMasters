using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mov : MonoBehaviour
{


    public float Speed;
    public Rigidbody rb;

    public float gravity;
    public float jumpforce;
    bool grounded;
    public float playerHeight;
    public LayerMask whatisGround;

    float horizontalInput;
    float verticalInput;

    public Transform orientation;
    public Vector3 moveDirection;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        grounded = Physics.Raycast(transform.position, Vector3.down, playerHeight * 0.5f * 0.2f, whatisGround);
        PlayerInput();
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

    public void MovePlayer()
    {
        moveDirection = orientation.forward * verticalInput + orientation.right * horizontalInput;
        rb.AddForce(10f * Speed * moveDirection.normalized, ForceMode.Force);
    }
}
