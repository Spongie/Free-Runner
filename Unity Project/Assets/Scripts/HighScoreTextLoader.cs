using UnityEngine;
using System.Collections;

public class HighScoreTextLoader : MonoBehaviour
{

    public HighScoreS1 highScores;
    public GUIText text;

    void Start() {
        string[] printList = highScores.GetPrintList();
        text.text = "Name   -  Time\n";
        for (int i = 0; i < printList.Length; i++)
        {
            text.text += printList[i];
        }
	}
}
