using UnityEngine;
using System.Collections;

public class QuestProgress
{
	public static int svanenMax;
	public static int svanenComp;

	public static int oskarMax;
	public static int oskarComp;

	public static int clausMax;
	public static int clausComp;

	public static int gertrudMax;
	public static int gertrudComp;

	public static int knutMax;
	public static int knutComp;

	public static int gripenMax;
	public static int gripenComp;

	public static int fransMax;
	public static int fransComp;

	public static int kyrkanMax;
	public static int kyrkanComp;

	public static int dissenMax;
	public static int dissenComp;

	public static int slottetMax;
	public static int slottetComp;

	public static int lejonetMax;
	public static int lejonetComp;

	public static int lillaTorgMax;
	public static int lillaTorgComp;

	public static int residentenMax;
	public static int residentenComp;

	public static void Update()
	{
		GameObject[] quests = GameObject.FindGameObjectsWithTag("Quest");
		Clear();
		foreach(GameObject item in quests)
		{
			Quest quest = item.GetComponent<Quest>();
			if(quest.område == "slottet")
			{
				slottetMax++;
				if(quest.Completed)
					slottetComp++;
			}

			if(quest.område == "oskar")
			{
				oskarMax++;
				if(quest.Completed)
					oskarComp++;
			}

			if(quest.område == "svanen")
			{
				svanenMax++;
				if(quest.Completed)
					svanenComp++;
			}

			if(quest.område == "residenten")
			{
				residentenMax++;
				if(quest.Completed)
					residentenComp++;
			}

			if(quest.område == "claus")
			{
				clausMax++;
				if(quest.Completed)
					clausComp++;
			}

			if(quest.område == "lilla Torg")
			{
				lillaTorgMax++;
				if(quest.Completed)
					lillaTorgComp++;
			}

			if(quest.område == "kyrkan")
			{
				kyrkanMax++;
				if(quest.Completed)
					kyrkanComp++;
			}

			if(quest.område == "gertrud")
			{
				gertrudMax++;
				if(quest.Completed)
					gertrudComp++;
			}

			if(quest.område == "knut")
			{
				knutMax++;
				if(quest.Completed)
					knutComp++;
			}

			if(quest.område == "frans")
			{
				fransMax++;
				if(quest.Completed)
					fransComp++;
			}

			if(quest.område == "dissen")
			{
				slottetMax++;
				if(quest.Completed)
					slottetComp++;
			}

			if(quest.område == "lejonet")
			{
				lejonetMax++;
				if(quest.Completed)
					lejonetComp++;
			}

			if(quest.område == "gripen")
			{
				gripenMax++;
				if(quest.Completed)
					gripenComp++;
			}

		}
	}

	static void Clear()
	{
		svanenMax = 0;
		svanenComp = 0;
		
		 oskarMax = 0;
		oskarComp = 0;
		
		clausMax = 0;
		clausComp = 0;
		
		gertrudMax=0;
		gertrudComp=0;
		
		knutMax=0;
		knutComp=0;
		
		gripenMax=0;
		gripenComp=0;
		
		fransMax=0;
		fransComp=0;
		
		kyrkanMax=0;
		kyrkanComp=0;
		
		dissenMax=0;
		dissenComp=0;
		
		slottetMax=0;
		slottetComp=0;
		
		lejonetMax=0;
		lejonetComp=0;
		
		lillaTorgMax=0;
		lillaTorgComp=0;
		
		residentenMax=0;
		residentenComp=0;
	}
}
