using UnityEngine;
using System.Collections;

public class Barbed_wire : MonoBehaviour {
    public ScoreManager scoreManager;
    
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 9)
        {
            other.gameObject.layer = 10;
            scoreManager.AddScore(HitType.MISS, other.gameObject.transform.position);
        }
    }
}
