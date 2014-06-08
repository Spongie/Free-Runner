using UnityEngine;
using System.Collections;
public enum Behaviour
{
	Walk,
	Idle
};

public class VillagerAI : MonoBehaviour {
	Vector3 randomDirection;
	NavMeshAgent agent;
	public float walkRadius;
	public Behaviour behaviour;
	float idleTime;
	public bool Walking;

	// Use this for initialization
	void Start () {
		agent = GetComponent<NavMeshAgent>();
		if(behaviour == Behaviour.Walk)
			SetPath();
	}

	// Update is called once per frame
	void Update () {
		if(behaviour == Behaviour.Walk)
			if(!agent.hasPath)
			{
				float behave = Random.Range(0,2);
				if(behave>0)
				{
				Walking = false;
					behaviour = Behaviour.Idle;
					behave = Random.Range(2,10);
					idleTime = behave;
				}
				else
					SetPath();
			}
		else
		{
			if(idleTime<=0)
			{	
				float behave = Random.Range(0,2);
				if(behave>0)
				{
					Walking = false;
					behaviour = Behaviour.Idle;
					behave = Random.Range(2,10);
					idleTime = behave;
				}
				else
					SetPath();
			}
			else
				idleTime -= Time.deltaTime;
		}
	}

	void SetPath()
	{
		Walking = true;
		randomDirection = Random.insideUnitSphere * walkRadius;
		randomDirection += transform.position;
		NavMeshHit hit;
		NavMesh.SamplePosition(randomDirection, out hit, walkRadius, 1);
		Vector3 finalPosition = hit.position;
		agent.SetDestination(finalPosition);
	}
}
