using UnityEngine;
using System.Collections;

[System.Serializable]
public class		Margins
{
	public float	great;
	public float	good;
	public float	ok;
    public float    miss;
}

[System.Serializable]
public class		DistanceProperties
{
	Vector3			_origin;
	public float 	distance;

	public Vector3	GetOrigin()
	{
		return _origin;
	}

	public void		SetOrigin(Vector3 origin)
	{
		_origin = origin;
	}
}

public class		ShootingScript : MonoBehaviour
{
	public ScoreManager			scoreManager;
	public Object 				projectile;
	public GameObject 			ship;
	public DistanceProperties	distanceProperties;
	public Margins				margins;
	public int					layerNumber;

	void			Start()
	{
		distanceProperties.SetOrigin(gameObject.transform.position);
	}
	
	void			Update()
	{
		if (Input.GetKeyDown(KeyCode.UpArrow))
			ShootInDirection(Vector3.forward);
		else if (Input.GetKeyDown(KeyCode.DownArrow))
			ShootInDirection(Vector3.back);
		else if (Input.GetKeyDown(KeyCode.LeftArrow))
			ShootInDirection(Vector3.left);
		else if (Input.GetKeyDown(KeyCode.RightArrow))
			ShootInDirection(Vector3.right);
	}

	void			OnTriggerExit(Collider other)
	{
		if (other.gameObject.layer == 13)
			Destroy(other.gameObject);
	}

	void			ShootInDirection(Vector3 direction)
	{
		RaycastHit 	hit;
		GameObject 	tmp;
		int 		layer = 1 << layerNumber;


		ship.transform.LookAt(gameObject.transform.position + direction);
		tmp = Instantiate(projectile, gameObject.transform.position, Quaternion.identity) as GameObject;
		tmp.transform.LookAt(gameObject.transform.position + direction);
		if (Physics.Raycast((distanceProperties.GetOrigin()), transform.TransformDirection(direction),
                out hit, distanceProperties.distance + margins.miss + 1, layer))
		{
            if (hit.collider == null)
				return;
            GetScore(hit.distance, hit.collider.gameObject.transform.position);
            DestroyGameObjectHit(hit.collider.gameObject);
        }
	}

	void			DestroyGameObjectHit(GameObject obj)
	{
		Destroy(obj);
	}

	bool			IsBetween(float nb, float min, float max)
	{
		return (nb >= min && nb <= max);
	}

	void			GetScore(float distance, Vector3 pos)
	{
		if (IsBetween(distance, distanceProperties.distance - margins.great, distanceProperties.distance + margins.great))
			scoreManager.AddScore(HitType.GREAT, pos);
		else if (IsBetween(distance, distanceProperties.distance - margins.good, distanceProperties.distance + margins.good))
			scoreManager.AddScore(HitType.GOOD, pos);
		else if (IsBetween(distance, distanceProperties.distance - margins.ok, distanceProperties.distance + margins.ok))
			scoreManager.AddScore(HitType.OK, pos);
		else
			scoreManager.AddScore(HitType.MISS, pos);
	}
}
