using UnityEngine;
using System.Collections;

public class		ProjectileMovement : MonoBehaviour
{
	public float	speed;
	[Range(1.0f, 20.0f)]
	public float 	lifetime;
	float			elapsedTime = 0;

	void			Start()
	{
	}
	
	void			Update()
	{
		transform.Translate(Vector3.forward * Time.deltaTime * speed);
		elapsedTime += Time.deltaTime;
		if (elapsedTime > lifetime)
			Destroy(gameObject);
	}

	void			OnTriggerEnter(Collider other)
	{
		if (other.gameObject.layer == 9)
			Destroy(gameObject);
	}
}
