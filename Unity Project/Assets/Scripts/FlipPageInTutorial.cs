using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public enum VilkenSida
{
	sida1,
	sida2,
	sida3
}

public class FlipPageInTutorial : MonoBehaviour {
	
	public VilkenSida sidan;
	GameObject textTitle1, textTitle2, textTitle3, textActualText1, textActualText2, textActualText3, textureScreenshot;
	
	// Use this for initialization
	void Start () {
		sidan = VilkenSida.sida1;
		textTitle1 = GameObject.Find("Tuturial_GUITxt_title1");
		textTitle2 = GameObject.Find("Tutorial_GUITxt_title2");
		textTitle3 = GameObject.Find("Tutorial_GUITxt_title3");
		textActualText1 = GameObject.Find("Tutorial_GUITxt_pg1txt");
		textActualText2 = GameObject.Find("Tutorial_GUITxt_pg2txt");
		textActualText3 = GameObject.Find("Tutorial_GUITxt_pg3txt");
		textureScreenshot = GameObject.Find("Tutorial_GUITexture_Page2");
	}
	
	#region Enable/Disable
	private void EnableSida1()
	{
		textTitle1.Enabled = true;
		textActualText1.Enabled = true;
	}
	private void EnableSida2()
	{
		textTitle2.Enabled = true;
		textActualText2.Enabled = true;
		textureScreenshot.Enabled = true;
	}
	private void EnableSida3()
	{
		textTitle3.Enabled = true;
		textActualText3.Enabled = true;
	}
	
	private void DisableSida1()
	{
		textTitle1.Enabled = false;
		textActualText1.Enabled = false;
	}
	private void DisableSida2()
	{
		textTitle2.Enabled = false;
		textActualText2.Enabled = false;
		textureScreenshot.Enabled = false;
	}
	private void DisableSida3()
	{
		textTitle3.Enabled = false;
		textActualText3.Enabled = false;
	}
	#endregion Enable/Disable
	
	// Update is called once per frame
	void Update () {
		switch (sidan){
		case VilkenSida.sida1:
			EnableSida1();
			DisableSida2();
			DisableSida3();
			break;
		case VilkenSida.sida2:
			DisableSida1();
			EnableSida2();
			DisableSida3();
			break;
		case VilkenSida.sida3:
			DisableSida1();
			DisableSida2();
			EnableSida3();
			break;
		}
	}
}