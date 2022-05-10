using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotate : MonoBehaviour
{
    public Rigidbody rb;
    public GameObject gameobj;
    private float rotation = 0;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        
        rotation += 0.1f ;
        if(gameobj.name == "rocket")
        rb.rotation = Quaternion.Euler(new Vector3(-90, rotation, 0));
        else
            rb.rotation = Quaternion.Euler(new Vector3(0, rotation, 0));
    }
}
