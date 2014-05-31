using UnityEngine;
using System.Collections;

public class DiscoveryBar : MonoBehaviour {

    public float maxAwareness;
    public float awareness;
    public float percentOfAwareness;
    public float awarenessRate;
    public GUITexture alertBar;
    float maxHeight;

    void Start()
    {
        GameObject[] objs = GameObject.FindGameObjectsWithTag("Quest");
        maxAwareness = objs.Length;
        maxHeight = 1000;
    }

	void Update()
	{
		ChangeAlertBar();
	}
    public void RaiseAwareness()
    {
        if (maxAwareness > awareness)
        {
            awareness += awarenessRate;
            ChangeAlertBar();
        }
    }

    public void ChangeAlertBar()
    {
		awareness = 0;
		GameObject[] quests = GameObject.FindGameObjectsWithTag("Quest");
		foreach (GameObject item in quests)
		{
			Quest quest = item.GetComponent<Quest>();
			if (quest.description == "Avklarad!")
			{
				++awareness;
			}
		}
        percentOfAwareness = awareness / maxAwareness;
        Rect alerter = alertBar.pixelInset;
        alerter.height = (maxHeight * percentOfAwareness);
        alertBar.pixelInset = alerter;
    }
}
