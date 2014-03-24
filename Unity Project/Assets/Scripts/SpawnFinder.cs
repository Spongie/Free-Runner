﻿using UnityEngine;
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

    public Vector3 GetClosestSpawn(Vector3 startPos)
    {
        GameObject[] objs = GameObject.FindGameObjectsWithTag("SpawnPoint");
        spawnPoints = new SpawnPoint[objs.Length];
        Vector3 closest = Vector3.zero;
        float minDistance = float.MaxValue;
        for (int i = 0; i < objs.Length; i++)
        {
            spawnPoints[i] = objs[i].GetComponent<SpawnPoint>();
            float distance = Mathf.Abs(Vector3.Distance(startPos, spawnPoints[i].transform.position));
            if (distance < minDistance)
            {
                minDistance = distance;
                closest = spawnPoints[i].GetSpawnPosition();
            }
        }
        return closest;
    }

    void OnDisable()
    {
        Debug.Log("Disabling player");
    }
}
