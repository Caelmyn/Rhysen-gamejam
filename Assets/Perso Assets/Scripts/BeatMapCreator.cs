using UnityEngine;
using System.Collections;
using System.IO;

public class BeatMapCreator : MonoBehaviour {
    public string mapName = "mapped.beatmap";
    private StreamWriter sw;
    public float delay = 3.7f;

	// Use this for initialization
	void Start () {
        sw = new StreamWriter(Application.persistentDataPath + "/" + mapName);
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Space)) {
            sw.Write((Time.time - delay).ToString("0.000") + "f");
        }
	}

    void OnDestroy()
    {
        sw.Close();
    }
}
