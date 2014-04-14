using UnityEngine;
using System.Collections;

public class JumpStick : MonoBehaviour {

    GUITexture guiTexture;
    public float jumpPower;
    float timeBetweenJumps;
    float timeSinceLastJump;

	void Start () {
        guiTexture = GetComponent<GUITexture>();
        timeBetweenJumps = 0.5f;
        timeSinceLastJump = 0;
	}
	
	void Update () {
        timeSinceLastJump += Time.deltaTime;
        for (int i = 0; i < Input.touchCount; i++)
        {
            if (guiTexture.GetScreenRect().Contains(Input.touches[i].position))
                Jump();
        }
	}

    void Jump()
    {
        if (timeSinceLastJump < timeBetweenJumps)
            return;
        timeBetweenJumps = 0;
        GameObject playerObj = GameObject.FindGameObjectWithTag("Player");
        if (Mathf.Abs(playerObj.GetComponent<Rigidbody>().velocity.y) > 0.02f)
            return;
        playerObj.GetComponent<Rigidbody>().AddForce(Vector3.up * jumpPower);
        playerObj.GetComponent<AnimationStarter>().Jump();
    }
}
