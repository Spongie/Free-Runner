using UnityEngine;
using System.Collections;

public class Movment : MonoBehaviour {

	Vector2 startPos;
	Vector2 curentPos;
	public float jumpPower;
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
		/*if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Moved) {
			Move ();
		}
		else if (Input.GetTouch(0).phase == TouchPhase.Began)
			startPos = Input.GetTouch(0).deltaPosition;*/
		if(movmentStick.GetScreenRect().Contains(Input.mousePosition) && Input.GetMouseButtonDown(0))
		{
			Debug.Log("Started Moving");
			moving = true;
		}
		if(Input.GetMouseButtonUp(0) && moving)
			moving = false;
		
		if(moving)
		{
			curentPos = Input.mousePosition;
			Move();
		}
	}
	
	void Move()
	{
		Vector3 Ddirection = playerObj.transform.forward;
		if(curentPos.y < startPos.y)
			Ddirection *= -1;
		direction = Ddirection.normalized;
		playerObj.transform.Translate(direction*Time.deltaTime, Space.World);
		
	}
}

