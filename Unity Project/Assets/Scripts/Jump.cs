using UnityEngine;
using System.Collections;

public class Jump : MonoBehaviour {

	public float power;
	public Rigidbody playerBody;
    float timeBetweenJumps;
    float timeSinceLastJump;

    void Start()
    {
        timeBetweenJumps = 0.5f;
        timeSinceLastJump = 0;
    }

	void Update () {
        timeSinceLastJump += Time.deltaTime;

		if(Input.GetKeyDown(KeyCode.Space))
			DoJump();
	}

	void DoJump()
	{
		playerBody.AddForce(Vector3.up * power);
        GetComponent<AnimationStarter>().Jump();
	}
}
