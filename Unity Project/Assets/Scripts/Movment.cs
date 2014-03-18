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

        moving = false;
        for(int i = 0; i < Input.touchCount; i++)
		{
            
			if(Input.touches[i].position.x > 1280)
			{
                Rect s = movmentStick.GetScreenRect();
                s.Set(s.x - 100, s.y - 150, s.xMax + 200, s.yMax + 350);
				if(s.Contains(Input.GetTouch(i).position))
				{
					Debug.Log("Started Moving");
					moving = true;
                    curentPos = Input.GetTouch(i).position;
				}
			}
		}
        if (moving)
            Move();
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

