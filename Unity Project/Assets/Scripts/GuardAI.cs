﻿using UnityEngine;
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

	// Use this for initialization
	void Start () {
		state = AIStates.Patroling;
	}
	
	// Update is called once per frame
	void Update () {
		if(IsAwareOfPlayer())
		{
			alarm.RaiseAwareness();
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
		Vector3 direction = patrolPoints[pointWalkedPast]-transform.position;
		direction.Normalize();
		transform.position+=(walkSpeed*direction*Time.deltaTime);

		if(Vector3.Distance(patrolPoints[pointWalkedPast], transform.position)<1)
			if(pointWalkedPast == patrolPoints.Length - 1)
				pointWalkedPast = 0;
			else
				pointWalkedPast++;
	}

	public void WalkRandom()
	{

	}

}
