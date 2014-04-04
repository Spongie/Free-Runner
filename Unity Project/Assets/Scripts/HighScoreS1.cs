using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.IO;

public class HighScoreS1 : MonoBehaviour 
{
	List<string> highScoreNames;
	List<string> highScoreTimes;

    string fileNameTime;
    string fileNameName;

    public string[] GetPrintList()
    {
        List<String> scores = new List<string>();
        highScoreNames = LoadScoreNames();
        highScoreTimes = LoadScoreTime();

        scores.Add(String.Format("{0, -20} {1, 20}\n", "Name", "Time"));

        for (int i = 0; i < highScoreNames.Count; i++)
        {
            scores.Add(String.Format("{0, -20} {1, 20}\n", highScoreNames[i], highScoreTimes[i]));
        }

        return scores.ToArray();
    }
	
	public void AddScore(string name, int time)
	{
        fileNameName = Application.persistentDataPath + "/names.txt";
        fileNameTime = Application.persistentDataPath + "/times.txt";
		highScoreNames = LoadScoreNames();
		highScoreTimes = LoadScoreTime();
		highScoreNames.Add(name);
		highScoreTimes.Add(time.ToString());
		Sort();
		TrimToTop10();
		SaveToFile();
	}
	
	public List<string> LoadScoreNames()
	{
		List<string> rList = new List<string>();
		if (File.Exists(fileNameName))
		{
			string[] highScoreN = System.IO.File.ReadAllLines(fileNameName);
			rList.AddRange(highScoreN);
		}
		return rList;
	}

	public List<string> LoadScoreTime()
	{
		List<string> rList = new List<string>();
		if (File.Exists(fileNameTime))
		{
            string[] highScoreT = System.IO.File.ReadAllLines(fileNameTime);
			rList.AddRange(highScoreT);
		}
		return rList;
	}

	private void Sort()
	{
		bool done = false;
		while(!done)
		{
			int changes = 0;
			for(int i = 0; i < highScoreTimes.Count - 1; i++)
			{
				if(int.Parse(highScoreTimes[i]) < int.Parse(highScoreTimes[i+1]))
				{
					Swap (i);
					changes++;
				}
			}

			if(changes == 0)
			{
				done = true;
			}
		}
	}

	private void Swap(int index)
	{
		string temp = highScoreTimes[index];
		highScoreTimes[index] = highScoreTimes[index + 1];
		highScoreTimes[index + 1] = temp;
		temp = highScoreNames[index];
		highScoreNames[index] = highScoreNames[index + 1];
		highScoreNames[index + 1] = temp;
	}

	private void TrimToTop10()
	{
		if (highScoreNames.Count <= 10)
			return;
		while (highScoreNames.Count != 10)
		{
			highScoreNames.RemoveAt (highScoreNames.Count - 1);
			highScoreTimes.RemoveAt (highScoreTimes.Count - 1);
		}
	}

	private void SaveToFile()
	{
        System.IO.File.WriteAllLines(fileNameTime, highScoreTimes.ToArray());
		System.IO.File.WriteAllLines(fileNameName, highScoreNames.ToArray());
	}
}