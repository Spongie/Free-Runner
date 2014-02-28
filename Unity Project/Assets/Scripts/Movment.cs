using UnityEngine;
using System.Collections;

public class Movment : MonoBehaviour {
	public Transform player;
	public Vector2 startPos;
	public Vector2 curentPos;
	public float jumpPower;

	void Update () {
		/*if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Moved) {
			Move ();
		}
		else if (Input.GetTouch(0).phase == TouchPhase.Began)
			startPos = Input.GetTouch(0).deltaPosition;*/
		
		if(Input.GetMouseButton(0)&& startPos.x > -100000)
		{
			curentPos = Input.mousePosition;
			Move();
		}
		else if(Input.GetMouseButton(0) && startPos.x == -100000)
		{
			startPos = Input.mousePosition;
			Move();
		}
		else
			startPos.x = -100000;
 		if (Input.GetKeyDown (KeyCode.Space))
     			 Jump();
	}
	
	void Move()
	{
		
		Vector2 direction = startPos-curentPos;
		direction.Normalize();
		
		transform.position += new Vector3(direction.x,0,direction.y)*Time.deltaTime;
		
	}
	void Jump()
	{
		Rigidbody r = GetComponent<Rigidbody> ();
      		r.AddForce (Vector3.up * jumpPower);
	}
}

