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

    public Canvas Levelsinfo;
    public TextMeshProUGUI Chapter;
    public TextMeshProUGUI Level;
    public TextMeshProUGUI Planet;
    public RawImage backgroundC;

    void Start()
    {
        Cursor.visible = false;
    }


    void Update()
    {
        responsive();

        Ray ray = MainCam.ScreenPointToRay(Input.mousePosition);
        RaycastHit hitInfo;

        if(Physics.Raycast (ray, out hitInfo))
        {
            if (hitInfo.rigidbody.gameObject.CompareTag("Chapter1"))
            {
                Fov(30);
                Levelsinfo.enabled = true;
                Display("Chapter - 1", "Earth", "");
            }else
            if (hitInfo.rigidbody.gameObject.CompareTag("C1"))
            {
                Fov(10);
                Levelsinfo.enabled = true;
                Display("C - 1", "astriod", "");
            }

        }
        else
        {
            Fov(60);
            Levelsinfo.enabled = false;
        }

    }


    public void Fov(float fov)
    {
        MainCam.fieldOfView = Mathf.Lerp(MainCam.fieldOfView, fov, t);
    }

    public void Display(string chapter, string planet, string level)
    {
        Chapter.text = chapter;
        Level.text = level;
        Planet.text = planet;
    }

    public void responsive()
    {
        float width = MainCam.pixelWidth;
        float height = MainCam.pixelHeight;

        Chapter.transform.position = new Vector3((width / (width / 10)) + 200, height/ 2 +160, 0);
        Level.transform.position = new Vector3((width / (width / 10)) + 200, height / 2 + 90, 0);
        Planet.transform.position = new Vector3((width / (width / 10)) + 200, height / 2 , 0);
        backgroundC.transform.position = new Vector3((width / (width / 10)) + 200, height / 2 +100, 0);
    }
}

