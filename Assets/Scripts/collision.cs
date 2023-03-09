using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class collision : MonoBehaviour
{

    public void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.CompareTag("Player")) Destroy(other.gameObject);
    }
}
