using UnityEngine;
using System.Collections;

public class ZombieWalk : MonoBehaviour {
    [Range(0.2f, 20.0f)]
    public float    speed = 1.0f;

    void Start() {
        transform.LookAt(new Vector3(0.0f, 1.4f, 0.0f), Vector3.up);
    }

	// Update is called once per frame
	void Update () {
        transform.Translate(Vector3.forward * Time.deltaTime * speed, Space.Self);
	}
}
