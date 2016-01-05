using UnityEngine;
using System.Collections;

public class 	TheFarLands : MonoBehaviour
{
	void 		Start()
	{
	}
	
	void 		Update()
	{
	}

	void 		OnTriggerExit(Collider other)
	{
		if (other.gameObject.layer != 8)
			Destroy(other.gameObject);
	}
}
