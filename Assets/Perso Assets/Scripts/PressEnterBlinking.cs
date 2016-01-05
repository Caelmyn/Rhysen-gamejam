using UnityEngine;
using System.Collections;

public class	PressEnterBlinking : MonoBehaviour
{
	float		timelapse = 0;
	bool		visible;

	void		Start()
	{
	}
	
	void		Update()
	{
		timelapse += Time.deltaTime;
		if (timelapse < 0.5)
			return ;
		visible = (visible ? false : true);
		timelapse = 0;
		gameObject.GetComponent<GUITexture>().enabled = visible;
	}
}
