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
		Touch touch = null;
		for(int i = 0; i < Input.touchCount)
		{
			if(Input.touches[i].position.x >0)
				touch = Input.touches[i];
		}
		if(touch != null)
		{
			if(movmentStick.GetScreenRect().Contains(touch))
			{
				Debug.Log("Started Moving");
				moving = true;
			}
			else
				moving = false;

			if(moving)
			{
				curentPos = touch.position;
				Move();
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

