using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {
    public GameObject endGameManager;
    public ParticleSystem ring;
    public Color minDanger;
    public Color maxDanger;
    public AnimationCurve lerpSpeed;
    public Health_bar hpBar;
    public int maxHP = 10;
    public int hp;

	// Use this for initialization
	void Start () {
        hp = maxHP;
        UpdateSpotLight();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter(Collider other) {
        if (other.gameObject.layer == 10 || other.gameObject.layer == 9) {
            Destroy(other.gameObject);
            AddHP(2);
        }
    }

    void UpdateSpotLight()
    {
        ring.GetComponent<Renderer>().material.color = Color.Lerp(minDanger, maxDanger, lerpSpeed.Evaluate(1.0f / (float)(hp + 0.001f)));
    }

    public void AddHP(int amount)
    {
        hp += amount;
        if (hp > maxHP) {
            hp = maxHP;
        } else if (hp <= 0) {
            Instantiate(endGameManager, Vector3.zero, Quaternion.identity);
            Destroy(gameObject);
        }
        hpBar.SetPercentage(hp);
        UpdateSpotLight();
    }

    public void RemoveHP(int amount)
    {
        hp -= amount;
        if (hp > maxHP) {
            hp = maxHP;
        } else if (hp <= 0) {
            Instantiate(endGameManager, Vector3.zero, Quaternion.identity);
            Destroy(gameObject);
        }
        hpBar.SetPercentage(hp);
        UpdateSpotLight();
    }
}
