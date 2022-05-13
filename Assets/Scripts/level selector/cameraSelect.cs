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
    public TextMeshProUGUI Lock;
    public TextMeshProUGUI Planet;
    public RawImage backgroundC;

    void Start()
    {
    }


    void Update()
    {
        responsive();

        Ray ray = MainCam.ScreenPointToRay(Input.mousePosition);
        RaycastHit hitInfo;

        if (Physics.Raycast(ray, out hitInfo))
        {
            GameObject other = hitInfo.rigidbody.gameObject;
            if (other.CompareTag("Chapter1"))
            {
                Pos(30, other.transform.position, 100);
                Levelsinfo.enabled = true;
                Display("Chapter - 1", "Earth", "");
            }
            else
            if (other.CompareTag("C1"))
            {
                Pos(30, other.transform.position, 40);
                Levelsinfo.enabled = true;
                Display("C - 1", "Astriod", other.name);
            }
            else
            if (other.CompareTag("moons"))
            {
                Pos(30, other.transform.position, 60);
                Levelsinfo.enabled = true;
                Display("Chapter - 2", "Moon", "");
            }

        }
        else
        {
            Pos(60, this.transform.position, 0);
            Levelsinfo.enabled = false;
        }

    }


    public void Pos(float fov, Vector3 pos, float High)
    {
        float xpos = MainCam.transform.position.x;
        float ypos = MainCam.transform.position.y;
        float zpos = MainCam.transform.position.z;
        MainCam.fieldOfView = Mathf.Lerp(MainCam.fieldOfView, fov, t);
        MainCam.transform.position = new Vector3(Mathf.Lerp(xpos, pos.x, t), Mathf.Lerp(ypos, pos.y + High, t), Mathf.Lerp(zpos, pos.z, t));
    }

    public void Display(string chapter, string planet, string level)
    {
        Chapter.text = chapter + " - " + level;
        Planet.text = planet;
    }

    public void responsive()
    {
        float width = MainCam.pixelWidth;
        float height = MainCam.pixelHeight;

        Chapter.transform.position = new Vector3((width / (width / 10)) + 200, height/ 2 +160, 0);
        Planet.transform.position = new Vector3((width / (width / 10)) + 200, height / 2 +90, 0);
        backgroundC.transform.position = new Vector3((width / (width / 10)) + 200, height / 2 +100, 0);
    }
}

