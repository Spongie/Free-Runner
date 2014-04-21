using UnityEngine;
using System.Collections;

public class JumpStick : MonoBehaviour {

    GUITexture guiTexture;
    public float jumpPower;
    float timeBetweenJumps;
    float timeSinceLastJump;
    float currentPower;
    GameObject playerObj;
    int elapsed = 0;
    bool checkGrounded;

	void Start () {
        guiTexture = GetComponent<GUITexture>();
        timeBetweenJumps = 0.5f;
        timeSinceLastJump = 0;
        currentPower = -1;
        checkGrounded = false;
	}
	
	void Update () {
        timeSinceLastJump += Time.deltaTime;
        for (int i = 0; i < Input.touchCount; i++)
        {
            if (guiTexture.GetScreenRect().Contains(Input.touches[i].position))
                Jump();
        }
        if (Input.GetKeyDown(KeyCode.K))
            Jump();
        if (currentPower > 0)
            DoJump();
	}

    void FixedUpdate()
    {
        elapsed++;
        if (elapsed > 10)
        {
            checkGrounded = true;
            elapsed = 0;
        }
    }

    void Jump()
    {
        Debug.Log("Jumping");
        if (timeSinceLastJump < timeBetweenJumps)
            return;
        timeBetweenJumps = 0;
        playerObj = GameObject.FindGameObjectWithTag("Player");
        if (Mathf.Abs(playerObj.GetComponent<CharacterController>().velocity.y) > 0.02f)
            return;
        currentPower = jumpPower;
        checkGrounded = false;
        playerObj.GetComponent<AnimationStarter>().Jump();
    }

    void DoJump()
    {
        if (playerObj.GetComponent<CharacterController>().isGrounded && checkGrounded)
            currentPower = -1;
        playerObj.GetComponent<CharacterController>().Move(Vector3.up * currentPower * Time.deltaTime);
        currentPower -= Time.deltaTime * 9.82f / 2;
    }
}
