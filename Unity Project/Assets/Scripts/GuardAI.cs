using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public enum AIStates
{
	Idle,
	Walking,
	Patroling
}

public class GuardAI : MonoBehaviour {
	public float detectRadius;
	public GameObject player;
	public Alarm alarm;
	public Vector3[] patrolPoints;
	int pointWalkedPast;
	public float walkSpeed;
	AIStates state;
	public NavMeshAgent agent;


	// Use this for initialization
	void Start () {
		state = AIStates.Patroling;
		agent.SetDestination(patrolPoints[0]);
	}
	
	// Update is called once per frame
	void Update () {
		if(IsAwareOfPlayer())
		{
			alarm.isAwareOfPlayer = true;
		}
		switch(state)
		{
		case AIStates.Patroling:
			Patroling();
			break;

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

	public void Patroling()
	{
		if(!agent.hasPath)
		{
			if(pointWalkedPast == patrolPoints.Length - 1)
				pointWalkedPast = 0;
			else
				pointWalkedPast++;
			agent.SetDestination(patrolPoints[pointWalkedPast]);
		}

	}

	public void WalkRandom()
	{

	}

}
