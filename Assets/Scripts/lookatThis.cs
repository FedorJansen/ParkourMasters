using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lookatThis : MonoBehaviour
{
    public GameObject moon;
    public Vector3 targetPoint;
    private float t = 0.1f;
    private float timeCount;

    
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
            
        }

        
        this.transform.LookAt(targetPoint);

      if(targetPoint.x + targetPoint.y > 45 && targetPoint.x + targetPoint.y < 60)
        {
            timeCount = timeCount + Time.deltaTime ;
            moon.transform.rotation = Quaternion.Lerp(moon.transform.rotation,Quaternion.Euler(0,0,0), t) ;
        }
    }
}
