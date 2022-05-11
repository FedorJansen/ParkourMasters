using UnityEngine;
using System.Collections;

public class EarthSpinScript : MonoBehaviour {
    public float speed = 10f;

    void Update() {
        transform.Rotate(Vector3.up + Vector3.left, speed * Time.deltaTime, Space.World);
    }
}