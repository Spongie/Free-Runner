using UnityEngine;
using System.Collections;

public class winnerTextLoader : MonoBehaviour {

	// Use this for initialization
	void Start () {
        GUIText text = GetComponent<GUIText>();
		string poängText = PlayerPrefs.GetString("time");
		float poäng = 0;
		float.TryParse(poängText,out poäng);
		int riktigPoäng = (int)poäng;
        text.text = "Grattis " + PlayerPrefs.GetString("winner") + "\n Du klarade spelet på " +riktigPoäng.ToString()+"sekunder";
	}

}
