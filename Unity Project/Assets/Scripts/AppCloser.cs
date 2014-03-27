using UnityEngine;
using System.Collections;

public class AppCloser : MonoBehaviour {

    public GameSaver gameSaver;

	void Update () {
        if (Input.GetKey(KeyCode.Escape))
        {
            gameSaver.SaveScene();
            Application.Quit();
        }
	}
}
