using UnityEngine;
using System.Collections;

public class JumpStick : MonoBehaviour {

    GUITexture guiTexture;
    public float jumpPower;

	void Start () {
        guiTexture = GetComponent<GUITexture>();
	}
	
	void Update () {
        for (int i = 0; i < Input.touchCount; i++)
        {
            if (guiTexture.GetScreenRect().Contains(Input.touches[i].position))
                Jump();
        }
	}

    void Jump()
    {
        GameObject playerObj = GameObject.FindGameObjectWithTag("Player");
        if (Mathf.Abs(playerObj.GetComponent<Rigidbody>().velocity.y) > 0.05f)
            return;
        playerObj.GetComponent<Rigidbody>().AddForce(Vector3.up * jumpPower);
        playerObj.GetComponent<AnimationStarter>().Jump();
    }
}
