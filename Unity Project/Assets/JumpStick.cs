using UnityEngine;
using System.Collections;

public class JumpStick : MonoBehaviour {

    GUITexture guiTexture;
    public float jumpPower;

	void Start () {
        guiTexture = GetComponent<GUITexture>();
	}
	
	void Update () {
        if (Input.GetMouseButtonDown(0))
        {
            if (guiTexture.GetScreenRect().Contains(Input.mousePosition))
                Jump();
        }
	}

    void Jump()
    {
        GameObject playerObj = GameObject.FindGameObjectWithTag("Player");
        playerObj.GetComponent<Rigidbody>().AddForce(Vector3.up * jumpPower);
        playerObj.GetComponent<AnimationStarter>().Jump();
    }
}
