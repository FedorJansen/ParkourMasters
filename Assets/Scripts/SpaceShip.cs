using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceShip : MonoBehaviour
{
    public Vector3 biem;
    public float Paf;
    public Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        biem = new Vector3(0.0f, 21.0f, 0.0f);
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            rb.AddForce(biem * Paf, ForceMode.Force);
            Debug.Log("HIT");
        }
    }
}
