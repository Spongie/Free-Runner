using UnityEngine;
using System.Collections;

public class Movment : MonoBehaviour {

	Vector2 startPos;
	Vector2 curentPos;
	public float speed;
	Vector3 direction;
	public GUITexture movmentStick;
	bool moving;
	GameObject playerObj;

	void Start()
	{
		playerObj = GameObject.FindGameObjectWithTag("Player");
		moving = false;
		startPos = movmentStick.GetScreenRect().center;
	}

	void Update () {
		for(int i = 0; i < Input.touchCount; i++)
		{
			if(Input.touches[i].position.x >0)
			{
				if(movmentStick.GetScreenRect().Contains(Input.GetTouch(i).position))
				{
					Debug.Log("Started Moving");
					moving = true;
				}
				else
					moving = false;
				
				if(moving)
				{
					curentPos = Input.GetTouch(i).position;
					Move();
				}
			}
		}
	}
	
	void Move()
	{
		Vector3 Ddirection = playerObj.transform.forward;
		if(curentPos.y < startPos.y)
			Ddirection *= -1;
		direction = Ddirection.normalized;
		playerObj.transform.Translate(direction*Time.deltaTime*speed, Space.World);
		
	}
}

