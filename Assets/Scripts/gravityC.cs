using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gravityC : MonoBehaviour
{
    public gravityOrbit gravity;
    private Rigidbody rb;

    public float RotationSpeed = 20;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (gravity)
        {
            Vector3 gravityUp = Vector3.zero;



            gravityUp = (transform.position - gravity.transform.position).normalized;



            Vector3 localUp = transform.up;



            Quaternion targetRotation = Quaternion.FromToRotation(localUp, gravityUp) * transform.rotation;
            rb.GetComponent<Rigidbody>().rotation = targetRotation;




            transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, RotationSpeed * Time.deltaTime);
            rb.GetComponent<Rigidbody>().AddForce((-gravityUp * gravity.Gravity) * rb.mass);
        }
    }
}


