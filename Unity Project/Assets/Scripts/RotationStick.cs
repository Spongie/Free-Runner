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

        rotating = false;
		for(int i = 0; i < Input.touchCount; i++)
		{
			if(Input.touches[i].position.x < 1280)
			{
                Rect s = rotationStick.GetScreenRect();
                s.Set(s.x - 100, s.y - 150, s.xMax + 200, s.yMax + 350);
				if(s.Contains(Input.GetTouch(i).position))
				{
					Debug.Log("Started Rotating");
					rotating = true;
                    currentPos = Input.GetTouch(i).position;
				}
			}
		}

        if (rotating)
            Move();
	}

	void Move()
	{
		if(currentPos.x > startPos.x)
			player.transform.Rotate(Vector3.up, Time.deltaTime*rotationSpeed);
		else
			player.transform.Rotate(Vector3.up, -Time.deltaTime*rotationSpeed);

	}
}
