using UnityEngine;
using System.Collections;

public class Area : MonoBehaviour {

	public GUITexture PopUpBackground;
	public float secondsToDisplay;
	float currentTimeElapsed;
    public GUIText text;
    public bool destroyAble = false;

	void Start()
	{
		PopUpBackground.enabled = false;
		currentTimeElapsed = 0;
	}

	void Update()
	{
		if (PopUpBackground.enabled) 
		{
			Debug.Log("Background is up");
			currentTimeElapsed += Time.deltaTime;
            if (currentTimeElapsed > secondsToDisplay)
            {
				Debug.Log ("Message down");
                PopUpBackground.enabled = false;
                if (destroyAble)
                    Destroy(this.gameObject);
            }
		}
        text.enabled = PopUpBackground.enabled;

	}

	public void OnTriggerEnter(Collider collision)
	{

		if (collision.gameObject.tag == "Player") 
		{
			Debug.Log("Entered A new area");
            Debug.Log(destroyAble);
			PopUpBackground.enabled = true;
			currentTimeElapsed = 0;
            
		}
	}
}
