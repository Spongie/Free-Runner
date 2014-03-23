﻿using UnityEngine;
using System.Collections;

public class MenuButton : MonoBehaviour 
{
	GUITexture image;
    public string scenename;
	// Use this for initialization
	void Start () 
    {
        image = GetComponent<GUITexture>();	
	}
	
	// Update is called once per frame
	void Update () 
	{
        if (image.GetScreenRect().Contains(Input.mousePosition) && Input.GetMouseButtonDown(0)) 
		{
			Application.LoadLevel (scenename);
		}
	}
	
}
