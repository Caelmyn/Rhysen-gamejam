using UnityEngine;
using System.Collections;

public class ScoreGUIElem : MonoBehaviour {
    const float lifeSpan = 0.4f;
    float deathTime;

	// Use this for initialization
	void Start () {
        deathTime = Time.time + lifeSpan;
	}
	
	// Update is called once per frame
	void Update () {
        if (Time.time >= deathTime) {
            Destroy(gameObject);
        }
	}
}
