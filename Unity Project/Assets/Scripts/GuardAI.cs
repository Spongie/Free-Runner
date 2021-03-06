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
	public Transform[] patrolPoints;
	int pointWalkedPast;
	public float walkSpeed;
	public AIStates state;
	public NavMeshAgent agent;
    public Animator animation;
    public bool randomized;

	// Use this for initialization
	void Start () {
		if(patrolPoints.Length==0||patrolPoints[0] == null)
			state = AIStates.Idle;
		else
			state = AIStates.Patroling;
	if(patrolPoints.Length>0 && patrolPoints[0] != null)
        	agent.SetDestination(patrolPoints[Random.Range(0, patrolPoints.Length)].position);
        animation = GetComponentInChildren<Animator>();
        player = GameObject.FindGameObjectWithTag("Player");
        alarm = GameObject.FindGameObjectWithTag("alertbar").GetComponent<Alarm>();
	}
	
	// Update is called once per frame
	void Update () {
        if (!GameOverStat.GameOver)
        {
            if (IsAwareOfPlayer())
            {
                alarm.isAwareOfPlayer = true;
            }
			if(animation != null)
			{
            switch (state)
            {
                case AIStates.Patroling:
                    agent.enabled = true;
                    Patroling();
                    animation.SetBool("Patrolling", true);
                    break;
                case AIStates.Idle:
                    agent.enabled = false;
                    animation.SetBool("Patrolling", false);
                    break;

            }
			}
        }
	}

	public bool IsAwareOfPlayer()
	{
		RaycastHit hit = new RaycastHit();
		Vector3 playerPos = new Vector3(player.transform.position.x,player.transform.position.y+1,player.transform.position.z);
		Vector3 dir = playerPos - transform.position;
		float length = Vector3.Distance(player.transform.position,transform.position);
		if(Physics.Raycast(transform.position,dir,out hit,detectRadius) )
		{
			if(hit.transform.tag == "Player")
			{
				return true;
			}
		}
		
		return false;
	}

	public void Patroling()
	{
        if (!agent.hasPath)
        {
            if (pointWalkedPast == patrolPoints.Length - 1)
                pointWalkedPast = 0;
            else
                pointWalkedPast++;
            if (!randomized)
                agent.SetDestination(patrolPoints[pointWalkedPast].position);
            else
                agent.SetDestination(patrolPoints[Random.Range(0, patrolPoints.Length)].position);
            
        }

	}

	public void WalkRandom()
	{

	}

}
