using UnityEngine;
using System.Collections;

public class SpawnPoint : MonoBehaviour {

	public string SpawnName = "defaultSpawnName";

	public Vector3 GetSpawnPosition()
	{
		Vector3 v = transform.position;
		v.y += 1;
		return v;
	}
}
