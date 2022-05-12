using UnityEngine;
using System.Collections;

public class EarthSpinScript : MonoBehaviour {
    public float speed = 10f;
    public GameObject[] moon;

    private void Start()
    {
        moon = GameObject.FindGameObjectsWithTag("moons");
    }
    void Update() {

        transform.Rotate(Vector3.up + Vector3.left, speed * Time.deltaTime, Space.World);
        moon[0].transform.Rotate(Vector3.up + Vector3.left, speed * Time.deltaTime, Space.World);
        moon[0].transform.RotateAround(Vector3.zero, Vector3.up, 0.36f * Time.deltaTime);
  

    }
}