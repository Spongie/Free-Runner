using UnityEngine;
using System.Collections;

public class RotationStick : MonoBehaviour {

	public GUITexture rotationStick;

	GameObject player;
	Vector2 startPos;
	Vector2 currentPos;
	bool rotating;
	public float rotationSpeed;

	void Start () {
		rotating = false;
		startPos = rotationStick.GetScreenRect().center;
		player = GameObject.FindGameObjectWithTag("Player");
	}

	void Update () {
		if(Input.GetMouseButtonDown(0) && rotationStick.GetScreenRect().Contains(Input.mousePosition))
			rotating = true;
		if(Input.GetMouseButtonUp(0))
			rotating = false;
		if(rotating)
		{
			currentPos = Input.mousePosition;
			Move();
		}
	}

	void Move()
	{
		if(currentPos.x > startPos.x)
			player.transform.Rotate(Vector3.up, Time.deltaTime*rotationSpeed);
		else
			player.transform.Rotate(Vector3.up, -Time.deltaTime*rotationSpeed);

	}
}
