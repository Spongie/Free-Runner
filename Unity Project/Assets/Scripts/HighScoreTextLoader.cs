using UnityEngine;
using System.Collections;

public class HighScoreTextLoader : MonoBehaviour
{
    public HighScoreS1 highScores;
    public GUIText text;

    public void Load()
    {
        string[] printList = highScores.GetPrintList();
        text.text = "";
        for (int i = 0; i < printList.Length; i++)
        {
            text.text += printList[i];
        }
    }
}