using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lookatThis : MonoBehaviour
{
    public Vector3 targetPoint;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    { 
    Plane plane = new Plane(Vector3.up, 0);
        
    Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        float distance;
        if (plane.Raycast(ray, out distance))
            {
             targetPoint = ray.GetPoint(distance);
            Debug.Log(targetPoint);
            
        }

        
        this.transform.LookAt(targetPoint);
    }
}
