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
	public Transform[] patrolPoints;
	int pointWalkedPast;
	public float walkSpeed;
	public AIStates state;
	public NavMeshAgent agent;
    public Animator animation;
    public bool randomized;

	// Use this for initialization
	void Start () {
        agent.SetDestination(patrolPoints[Random.Range(0, patrolPoints.Length+1)].position);
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
        if (!agent.hasPath)
        {
            if (pointWalkedPast == patrolPoints.Length - 1)
                pointWalkedPast = 0;
            else
                pointWalkedPast++;
            if (!randomized)
                agent.SetDestination(patrolPoints[pointWalkedPast].position);
            else
                agent.SetDestination(patrolPoints[Random.Range(0, patrolPoints.Length + 1)].position);
            
        }

	}

	public void WalkRandom()
	{

	}

}
