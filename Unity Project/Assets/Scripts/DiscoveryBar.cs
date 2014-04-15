using UnityEngine;
using System.Collections;

public class DiscoveryBar : MonoBehaviour {

    public float maxAwareness;
    public float awareness;
    public float percentOfAwareness;
    public float awarenessRate;
    public GUITexture alertBar;

    void Start()
    {
        GameObject[] objs = GameObject.FindGameObjectsWithTag("Quest");
        maxAwareness = objs.Length;
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
        percentOfAwareness = awareness / maxAwareness;
        Rect alerter = alertBar.pixelInset;
        alerter.height = (maxAwareness * percentOfAwareness);
        alertBar.pixelInset = alerter;
    }
}
