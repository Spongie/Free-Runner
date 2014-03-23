using UnityEngine;
using System.Collections;

public class MapText : MonoBehaviour 
{

    public GUIText beskrivning;

    public void SetText(string intext) 
    {
        beskrivning.text = intext;
    }
}
