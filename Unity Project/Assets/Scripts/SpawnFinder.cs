using UnityEngine;
using System.Collections;

public class SpawnFinder : MonoBehaviour {

	public Transform player;
	SpawnPoint[] spawnPoints;

	void Start()
	{
		player.position = GetStartSpawn();
		Debug.Log ("New Position: " + player.position);
	}

	public Vector3 GetStartSpawn()
	{
		GameObject[] objs = GameObject.FindGameObjectsWithTag ("SpawnPoint");
		spawnPoints = new SpawnPoint[objs.Length];
		for (int i = 0; i < objs.Length; i++)
		{
			spawnPoints[i] = objs[i].GetComponent<SpawnPoint>();
			if(spawnPoints[i].SpawnName == "StartSpawn")
				return spawnPoints[i].GetSpawnPosition();
		}
		return Vector3.zero;
	}
}
