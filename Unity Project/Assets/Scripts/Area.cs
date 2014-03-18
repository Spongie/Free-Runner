using UnityEngine;
using System.Collections;

public class Area : MonoBehaviour {

	public GUITexture PopUpBackground;
	public float secondsToDisplay;
	float currentTimeElapsed;
    GUIText text;

	void Start()
	{
        text = GetComponentInChildren<GUIText>();
		currentTimeElapsed = 0;
		PopUpBackground.enabled = false;
	}

	void Update()
	{
		if (PopUpBackground.enabled) 
		{
			currentTimeElapsed += Time.deltaTime;
			if(currentTimeElapsed > secondsToDisplay)
				PopUpBackground.enabled = false;
		}
        text.enabled = PopUpBackground.enabled;
	}

	public void OnTriggerEnter(Collider collision)
	{
		if (collision.gameObject.tag == "Player") 
		{
			Debug.Log("Entered A new area");
			PopUpBackground.enabled = true;
			currentTimeElapsed = 0;
		}
	}
}
