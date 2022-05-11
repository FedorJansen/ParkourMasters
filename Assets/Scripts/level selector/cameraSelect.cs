using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class cameraSelect : MonoBehaviour
{
    public Camera MainCam;
    public float t;
    public Canvas Levels;
    public TextMeshProUGUI level;
    public TextMeshProUGUI planet;

    void Start()
    {
        Cursor.visible = false;
    }


    void Update()
    {

        Ray ray = MainCam.ScreenPointToRay(Input.mousePosition);
        RaycastHit hitInfo;

        if(Physics.Raycast (ray, out hitInfo))
        {
            if (hitInfo.rigidbody.gameObject.CompareTag("Chapter1"))
            {
                Fov(30);
                Levels.enabled = true;
                
            }

        }
        else
        {
            Fov(60);
            Levels.enabled = false;
        }

    }


    void Fov(float fov)
    {
        float newFov = fov;
        MainCam.fieldOfView = Mathf.Lerp(MainCam.fieldOfView, fov, t);
    }
}

