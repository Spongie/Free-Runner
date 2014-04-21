using UnityEngine;
using System.Collections;

public class winnerTextLoader : MonoBehaviour {

	// Use this for initialization
	void Start () {
        GUIText text = GetComponent<GUIText>();
        text.text = "Grattis " + PlayerPrefs.GetString("winner") + "\n Du klarade spelet på " +PlayerPrefs.GetString("time");
	}

}
