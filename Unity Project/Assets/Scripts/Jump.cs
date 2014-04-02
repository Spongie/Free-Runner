using UnityEngine;
using System.Collections;

public class Jump : MonoBehaviour {

	public float power;
	public Rigidbody playerBody;

	void Update () {
		if(Input.GetKeyDown(KeyCode.Space))
			DoJump();
	}

	void DoJump()
	{
		playerBody.AddForce(Vector3.up * power);
        GetComponent<AnimationStarter>().Jump();
	}
}
