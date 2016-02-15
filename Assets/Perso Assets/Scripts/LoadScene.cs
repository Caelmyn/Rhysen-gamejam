using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class LoadScene : MonoBehaviour
{
    [SerializeField] private string _sceneName;

	void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
            Load();
	}

    public void Load()
    {
        SceneManager.LoadScene(_sceneName);
    }
}
