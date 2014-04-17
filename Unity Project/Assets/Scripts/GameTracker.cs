using UnityEngine;
using System.Collections;

public class GameTracker : MonoBehaviour {

    float secondsElapsed;
    float hoursElapsed;
    float minuetsElapsed;
    public bool active = false;

	void Start () {
        secondsElapsed = 0;
        hoursElapsed = 0;
        minuetsElapsed = 0;
	}
	
	void Update () {
        if (active)
        {
            AddTime();
            if (CheckGameCompleted())
            {
                Debug.Log("SPELET KLART");
                GetComponent<HighScoreS1>().AddScore("MALMÖ", (int)secondsElapsed);
                PlayerPrefs.DeleteAll();
                PlayerPrefs.SetString("winner", "MALMÖ");
                PlayerPrefs.SetString("time", GetTimeString());
                Application.LoadLevel("menu_finnish");
            }
        }
	}

    public string GetTimeString()
    {
        string s = string.Format("H:{0,1}:M{1,2}:S{2,2}", hoursElapsed, minuetsElapsed, secondsElapsed.ToString("f2"));
        return s;
    }

    bool CheckGameCompleted()
    {
        GameObject[] objs = GameObject.FindGameObjectsWithTag("Quest");
        int mainsDone = 0;
        int mains = 0;
        foreach (GameObject item in objs)
        {
            Quest quest = item.GetComponent<Quest>();
            if (quest.isMain)
                mains++;
            if (quest.isMain && quest.description == "Avklarad!")
                mainsDone++;
        }
        if (mainsDone >= mains)
            return true;
        return false;
    }

    void AddTime()
    {
        secondsElapsed += Time.deltaTime;
        if (secondsElapsed % 60 == 0)
        {
            minuetsElapsed++;
        }
        if (minuetsElapsed >= 60)
        {
            minuetsElapsed = 0;
            hoursElapsed++;
        }
    }

    public void SaveState()
    {
        Debug.Log("Saving state at: " + secondsElapsed);
        PlayerPrefs.SetFloat("sec", secondsElapsed);
        PlayerPrefs.SetFloat("min", minuetsElapsed);
        PlayerPrefs.SetFloat("hr", hoursElapsed);
    }

    public void LoadState()
    {
        if(!PlayerPrefs.HasKey("sec"))
            return;
        secondsElapsed = PlayerPrefs.GetFloat("sec");
        minuetsElapsed = PlayerPrefs.GetFloat("min");
        hoursElapsed = PlayerPrefs.GetFloat("hr");
        Debug.Log("Loaded state at: " + secondsElapsed);
    }
}
