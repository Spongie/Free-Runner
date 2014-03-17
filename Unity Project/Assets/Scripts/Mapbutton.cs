using UnityEngine;
using System.Collections;

public class Mapbutton : MonoBehaviour 
{
	public GUITexture timsmamma;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (timsmamma.GetScreenRect ().Contains (Input.mousePosition) && Input.GetMouseButtonDown(0)) 
		{
			Application.LoadLevel ("menu_karta");
		}
	}
	
}
