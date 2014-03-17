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
		Touch touch = null;
		for(int i = 0; i < Input.touchCount)
		{
			if(Input.touches[i].position.x <0)
				touch = Input.touches[i];
		}
		if(touch != null)
		{
			if(movmentStick.GetScreenRect().Contains(touch))
			{
				Debug.Log("Started Rotating");
				rotating = true;
			}
			else
				rotating = false;
			
			if(moving)
			{
				curentPos = touch.position;
				Move();
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
