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
  

    }
}