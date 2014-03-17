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
		for(int i = 0; i < Input.touchCount; i++)
		{
			if(Input.touches[i].position.x <0)
			{
				if(rotationStick.GetScreenRect().Contains(Input.GetTouch(i).position))
				{
					Debug.Log("Started Rotating");
					rotating = true;
				}
				else
					rotating = false;
				
				if(rotating)
				{
					currentPos = Input.GetTouch(i).position;
					Move();
				}
			}
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
