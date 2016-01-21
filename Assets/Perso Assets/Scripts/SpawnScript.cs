using UnityEngine;
using System.Collections;
using System.IO;

public class			SpawnScript : MonoBehaviour
{
	Queue _spawnTimes = new Queue();
	System.Random _rand;
	public TextAsset beatmap;
	float _nextSpawnTime = -1.0f;
	public ZombieWalk entity;
	private const float spawnRange = 60.0f;
	private const float ringRadius = 18.3f;
	public string mapName = "default.beatmap";
	public bool convert = false;
	private float delay = 4.50f;
	public Player player;
	public GameObject endGameManager;

	float _endGameTime = 0.0f;
	int _lastDirection = 0;

	void Start()
	{
		_rand = new System.Random();
		StringReader sr = new StringReader(beatmap.text);
		string fileContents = sr.ReadToEnd();
		sr.Close();

		string[] timeStamps = fileContents.Split('f');
		float newTime;
		foreach (string timeStamp in timeStamps) {
			float.TryParse(timeStamp, out newTime);
			if (newTime < 0.0f) {
				float travelTime = delay + newTime;
				if (travelTime > 0.0f) {
					SpawnZombie(travelTime * (spawnRange - ringRadius) / delay + ringRadius);
				}
			} else {
				_spawnTimes.Enqueue(newTime);
			}
		}
		_nextSpawnTime = -1.0f;
	}

	void Update()
	{
		if (_nextSpawnTime == -1.0f) {
			if (_spawnTimes.Count > 0) {
				_nextSpawnTime = (float)_spawnTimes.Peek();
			}
		} else if (_nextSpawnTime < Time.timeSinceLevelLoad) {
			if (_spawnTimes.Count > 0)
			{
				SpawnZombie();
				_spawnTimes.Dequeue();
				if (_spawnTimes.Count > 0)
				{
					_nextSpawnTime = (float)_spawnTimes.Peek();
				}
				else
				{
					_endGameTime = Time.timeSinceLevelLoad + delay;
				}
			}
		}
		if (_endGameTime != 0 && Time.timeSinceLevelLoad >= _endGameTime) {
			Destroy(player);
			Instantiate(endGameManager, Vector3.zero, Quaternion.identity);
			_endGameTime = 0.0f;
		}
	}

	void SpawnZombie(float dist = spawnRange) {
		Vector3	 pos;
		int direction;

		direction = _lastDirection + ((direction = _rand.Next() % 3) == 0 ? 0 : (direction == 1 ? 1 : -1));
		direction += (direction > 3 ? -4 : (direction < 0 ? 4 : 0));
		_lastDirection = direction;
		switch (direction)
		{
			case 0:
				pos = new Vector3(dist, 1.0f, 0.0f);
				break;
			case 1:
				pos = new Vector3(0, 1, dist);
				break;
			case 2:
				pos = new Vector3(-dist, 1, 0);
				break;
			case 3:
				pos = new Vector3(0, 1, -dist);
				break;
			default:
				return;
		}
		Instantiate(entity, pos, Quaternion.identity);
	}
}
