﻿using UnityEngine;
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
			currentTimeElapsed += Time.deltaTime;
            if (currentTimeElapsed > secondsToDisplay)
            {
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
            Debug.Log(destroyAble);
			PopUpBackground.enabled = true;
			currentTimeElapsed = 0;
            
		}
	}
}
