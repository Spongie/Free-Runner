using UnityEngine;
using System.Collections;

public class Alarm : MonoBehaviour {
	public float maxAwareness;
	public float awareness;
	public float percentOfAwareness;
	public float detectRadius;
	public float awarenessRate;
	public float awarenessDecereaseRate;
	public GUITexture alertBar;
    public GUITexture gameOverTexture;
    public float secondsToShowGameOver = 3f;
    float secondsElapsed;
	public bool isAwareOfPlayer;
    bool showing;

    void Start()
    {
        showing = false;
        secondsElapsed = 0f;
        InitGameOverTexture();
    }

    void InitGameOverTexture()
    {
        gameOverTexture.enabled = false;
        gameOverTexture.pixelInset = new Rect(0, 0, 0, 0);
        gameOverTexture.transform.position = new Vector3(0.5f, 0.5f, gameOverTexture.transform.position.z);
        gameOverTexture.transform.localScale = new Vector3(1f, 1f, gameOverTexture.transform.localScale.z);
    }

	void Update () {

        if (showing)
        {
            secondsElapsed += Time.deltaTime;
            if (secondsElapsed >= secondsToShowGameOver)
                GameOver();
        }
        else if (IsDetected())
            ShowGameOver();
		if(isAwareOfPlayer)
		{
			Debug.Log("Seeing you");
			RaiseAwareness();
		}
		else
		{
			Debug.Log("Not Seeing you");
            LowerAwareness();
		}

		ChangeAlertBar();
        isAwareOfPlayer = false;
	}

    void ShowGameOver()
    {
        secondsElapsed = 0.0f;
        showing = true;
        gameOverTexture.enabled = true;
    }

    void GameOver()
    {
        awareness = 0.0f;
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        player.transform.position = player.GetComponent<SpawnFinder>().GetClosestSpawn(player.transform.position);
        showing = false;
    }

	public void RaiseAwareness()
	{
		if(maxAwareness>awareness)
		{
			awareness += awarenessRate;
		}
	}

    public void LowerAwareness()
    {
        if (awareness > 0)
        {
            awareness -= (awarenessRate * 0.6f);
        }
    }

	public bool IsDetected()
	{
		return (awareness >= maxAwareness) ? true : false;
	}

	public void ChangeAlertBar()
	{
		percentOfAwareness = awareness/maxAwareness;
		Rect alerter = alertBar.pixelInset;
		alerter.height = (maxAwareness*percentOfAwareness);
		alertBar.pixelInset = alerter;
	}
}