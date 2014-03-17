using UnityEngine;
using System.Collections;

public class GuardAI : MonoBehaviour {
	public float detectRadius;
	public GameObject player;
	public Alarm alarm;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if(IsAwareOfPlayer())
		{
			alarm.RaiseAwareness();
		}
	}

	public bool IsAwareOfPlayer()
	{
		float length = Vector3.Distance(player.transform.position,transform.position);
		if(length <= detectRadius)
			return true;
		else 
			return false;
	}

}
