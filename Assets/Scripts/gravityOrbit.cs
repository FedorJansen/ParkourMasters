using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gravityOrbit : MonoBehaviour
{
    public float Gravity;

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<gravityC>())
        {
            other.GetComponent<gravityC>().gravity = this.GetComponent<gravityOrbit>();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.GetComponent<gravityC>())
        {
            other.GetComponent<gravityC>().gravity = null;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
