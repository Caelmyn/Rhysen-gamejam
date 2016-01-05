using UnityEngine;
using System.Collections;

public class	LaunchGame : MonoBehaviour
{

	void		Start()
	{
	}
	
	void		Update()
	{
		if (Input.GetKeyDown(KeyCode.Return))
			Application.LoadLevel("main");
	}
}
