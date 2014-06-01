using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public enum VilkenSida
{
	sida1,
	sida2,
	sida3,
	sida4
}

public class FlipPageInTutorial : MonoBehaviour {
	
	public VilkenSida sidan;
	public Font font;
	public int Size;
	public Texture2D knapp;
	public GameObject textTitle1, textTitle2, textTitle3, textTitle4, textActualText1, textActualText2, textActualText3, textActualText4, textureScreenshot, textureGuard, textureParticle;
	
	// Use this for initialization
	void Start () {
		sidan = VilkenSida.sida1;
		textTitle1 = GameObject.FindGameObjectWithTag("titel1");
		textTitle2 = GameObject.FindGameObjectWithTag("titel2");
		textTitle3 = GameObject.FindGameObjectWithTag("titel3");
		textTitle4 = GameObject.FindGameObjectWithTag("titel4");
		textActualText1 = GameObject.FindGameObjectWithTag("text1");
		textActualText2 = GameObject.FindGameObjectWithTag("text2");
		textActualText3 = GameObject.FindGameObjectWithTag("text3");
		textActualText4 = GameObject.FindGameObjectWithTag("text4");
		textureScreenshot = GameObject.Find("Tutorial_GUITexture_Page2");
		textureGuard = GameObject.Find("Tutorial_GUITexture_Page3");
		textureParticle = GameObject.Find("Tutorial_GUITexture_Page4");
	}
	
	#region Enable/Disable
	private void EnableSida1()
	{
		textTitle1.SetActive(true);
		textActualText1.SetActive(true);
	}
	private void EnableSida2()
	{
		textTitle2.SetActive(true);
		textActualText2.SetActive(true);
		textureScreenshot.SetActive(true);
	}
	private void EnableSida3()
	{
		textTitle3.SetActive(true);
		textActualText3.SetActive(true);
		textureGuard.SetActive(true);
	}
	private void EnableSida4()
	{
		textTitle4.SetActive(true);
		textActualText4.SetActive(true);
		textureParticle.SetActive(true);
	}
	
	private void DisableSida1()
	{
		textTitle1.SetActive(false);
		textActualText1.SetActive(false);
	}
	private void DisableSida2()
	{
		textTitle2.SetActive(false);
		textActualText2.SetActive(false);
		textureScreenshot.SetActive(false);
	}
	private void DisableSida3()
	{
		textTitle3.SetActive(false);
		textActualText3.SetActive(false);
		textureGuard.SetActive(false);
	}
	private void DisableSida4()
	{
		textTitle4.SetActive(false);
		textActualText4.SetActive(false);
		textureParticle.SetActive(false);
	}
	#endregion Enable/Disable
	
	// Update is called once per frame
	void Update () {
		switch (sidan){
		case VilkenSida.sida1:
			Debug.Log("sida 1");
			EnableSida1();
			DisableSida2();
			DisableSida3();
			DisableSida4();
			break;
		case VilkenSida.sida2:
			DisableSida1();
			EnableSida2();
			DisableSida3();
			DisableSida4();
			break;
		case VilkenSida.sida3:
			DisableSida1();
			DisableSida2();
			EnableSida3();
			DisableSida4();
			break;
		case VilkenSida.sida4:
			DisableSida1();
			DisableSida2();
			DisableSida3();
			EnableSida4();
			break;
		}
	}

	void OnGUI()
	{
		Rect sida1 = new Rect(20,420,450,150);
		Rect sida2 = new Rect(20,570,450,150);
		Rect sida3 = new Rect(20,720,450,150);
		Rect sida4 = new Rect(20,870,450,150);

		GUIStyle style = new GUIStyle();

		style.font = font;
		style.fontSize = Size;
		style.normal.background = knapp;
		style.alignment = TextAnchor.MiddleCenter;
		//GUI.Box(Rect(0, 0, 100, 100), "Sidor:");
		if (GUI.Button(sida1, "Sida 1",style)){
			sidan = VilkenSida.sida1;}
		if (GUI.Button(sida2, "Sida 2",style)){
			sidan = VilkenSida.sida2;}
		if (GUI.Button(sida3, "Sida 3",style)){
			sidan = VilkenSida.sida3;}
		if (GUI.Button(sida4, "Sida 4",style)){
			sidan = VilkenSida.sida4;}
	}
}