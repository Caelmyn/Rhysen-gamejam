using UnityEngine;
using System.Collections;

public class TravelThroughSpace : MonoBehaviour {
    public float xSpeed = 0.0f;
    public float ySpeed = 0.0f;
    public float zSpeed = 0.0f;

    void Update () {
        transform.Rotate(Vector3.left, xSpeed * Time.deltaTime);
        transform.Rotate(Vector3.up, ySpeed * Time.deltaTime);
        transform.Rotate(Vector3.back, zSpeed * Time.deltaTime);
	}
}
