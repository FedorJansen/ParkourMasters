using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mov : MonoBehaviour
{
    public Transform Floor;
    public float range = 15f;

    public float Speed;
    private float ShoesSpeed;
    public Rigidbody rb;

    public float maxSpeed;
    public float curMaxSpeed;
    private bool walking = true;
    public float Sprint;

    public bool isGrounded;
    public Vector3 jump;
    public bool jumped;
    public int jumps;
    private int jetpackJumps;

    public float gravity;
    public float jumpforce;
    public float groundDrag;
    public float PlayerHeight;

    public LayerMask Mask;

    float horizontalInput;
    float verticalInput;

    public GameObject FloorObject;

    public Transform orientation;
    public Vector3 moveDirection;
    public Vector3 CenterOfmass;


    void Start()
    {
        rb = GetComponent<Rigidbody>();
        jump = new Vector3(0.0f, 2.0f, 0.0f);
        orientation = rb.transform;
        jetpackJumps = GetComponent<PowerUps>().jetpackJumps;
        ShoesSpeed = GetComponent<PowerUps>().ShoesSpeed;

    }

    void Update()
    {
        PlayerInput();
        PlayerSpeed();
        PlayerDrag();

    }


    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Floor"))
            CenterOfmass = other.gameObject.transform.position;
        else
            CenterOfmass = Vector3.down;
    }

    public void PlayerDrag()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if(jumps >= 1)
            {
                rb.AddForce(jump * jumpforce, ForceMode.Impulse);
                jumps--;
            }
            else if(PowerUps.SPowerUps.jetpack.Equals(true) && !jumped)
            {
                rb.AddForce(jump * jumpforce, ForceMode.Impulse);
                jumped = true;
            }

        }

    }
    void PlayerInput()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");
    }

    private void FixedUpdate()
    {
        MovePlayer();


            Ray ray = new Ray(transform.position, -CenterOfmass);
        Debug.Log(CenterOfmass);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, 2, Mask, QueryTriggerInteraction.Ignore))
            {
                Debug.DrawLine(ray.origin, hit.point, Color.red);
                isGrounded = true;
                jumped = false;
                jumps = 1;
                rb.drag = groundDrag;
            }
            else
            {
                Debug.DrawLine(ray.origin, ray.origin + ray.direction * 2, Color.green);
                jumps = 0;
                rb.drag = 0;
            }


    }

    public void PlayerSpeed()
    {
        if (Input.GetKey(KeyCode.LeftShift))
        {
            walking = false;
            if (PowerUps.SPowerUps.shoes.Equals(true))
                curMaxSpeed = maxSpeed * Sprint + ShoesSpeed;
            else
                curMaxSpeed = maxSpeed * Sprint;
        }
        else

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
          if (PowerUps.SPowerUps.shoes.Equals(true))
              Speed *= Sprint + ShoesSpeed;
          else
                Speed *=  Sprint;
        }
        if (Input.GetKey(KeyCode.W) && isGrounded)
        {
            rb.AddForce(10f * Speed * moveDirection.normalized, ForceMode.Force);
        }
        else if (Input.GetKey(KeyCode.S) && isGrounded || Input.GetKey(KeyCode.D) && isGrounded || Input.GetKey(KeyCode.A) && isGrounded)
        {
            rb.AddForce(10f * (Speed - (Speed / 4)) * moveDirection.normalized, ForceMode.Force);
        }
        else if (isGrounded)
        {

        }
        else if (!isGrounded)
        {
            rb.AddForce(10f * (Speed / 6) * moveDirection.normalized, ForceMode.Force);
        }
        if (!walking)
        {
          if (PowerUps.SPowerUps.shoes.Equals(true))
              Speed /= Sprint + ShoesSpeed;
         else
            Speed /= Sprint;
        }

    }

}



