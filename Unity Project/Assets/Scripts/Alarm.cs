using UnityEngine;
using System.Collections;

public class Alarm : MonoBehaviour {
	public float maxAwareness;
	public float awareness;
	public float percentOfAwareness;
	public float detectRadius;
	public float awarenessRate;
	public GUITexture alertBar;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		if(Input.anyKey)
		{
			RaiseAwareness();
			ChangeAlertBar();
		}

		if(IsDetected())
			Debug.Log("Detected Bitch");
	}

	public bool IsAwareOfPlayer()
	{
		float enemyDistanceFromPlayer = 10;
		if(enemyDistanceFromPlayer<= detectRadius)
			return true;
		else 
			return false;
	}

	public void RaiseAwareness()
	{
		awareness += awarenessRate;
	}

	public bool IsDetected()
	{
		return (awareness >= maxAwareness) ? true : false;
	}

	public void ChangeAlertBar()
	{
		percentOfAwareness = awareness/maxAwareness;
		Rect alerter = alertBar.pixelInset;
		alerter.height = (200*percentOfAwareness);
		alertBar.pixelInset = alerter;
	}
}