using UnityEngine;
using System.Collections;
using System.IO;

public class Map_Button : MonoBehaviour {

    bool isselected;
    GUITexture image;
    public Texture selected;
    public Texture notselected;
    GameObject beskrivningsbox;
    public string QuestTargetName;
	public string Description;

    public bool Isselected 
    {
        get { return isselected; }
    }
	// Use this for initialization
	void Start () 
    {
        beskrivningsbox = GameObject.FindGameObjectWithTag("DescriptionBox");
        isselected = false;
        image = GetComponent<GUITexture>();
	}
	
	// Update is called once per frame
	void Update () 
    {
        if (IsCompleted())
        {
            image.enabled = false;
            
        }
        if (image.GetScreenRect().Contains(Input.mousePosition) && Input.GetMouseButtonDown(0))
        {
			string uppKlarade = string.Empty;
			if(QuestTargetName == "Diskontenten")
			{
				uppKlarade = QuestProgress.dissenComp.ToString() +"/"+QuestProgress.dissenMax.ToString();
			}
			if(QuestTargetName == "Frans Suell")
			{
				uppKlarade = uppKlarade = QuestProgress.fransComp.ToString() +"/"+QuestProgress.fransMax.ToString();
			}
			if(QuestTargetName == "Gripen")
			{
				uppKlarade = QuestProgress.gripenComp.ToString() +"/"+QuestProgress.gripenMax.ToString();
			}
			if(QuestTargetName == "Lejonet")
			{
				uppKlarade = QuestProgress.lejonetComp.ToString() +"/"+QuestProgress.lejonetMax.ToString();
			}
			if(QuestTargetName == "Lilla Torg")
			{
				uppKlarade = QuestProgress.lillaTorgComp.ToString() +"/"+QuestProgress.lillaTorgMax.ToString();
			}
			if(QuestTargetName == "Malmö Hus")
			{
				uppKlarade = QuestProgress.slottetComp.ToString() +"/"+QuestProgress.slottetMax.ToString();
			}
			if(QuestTargetName == "Oskar")
			{
				uppKlarade = QuestProgress.oskarComp.ToString() +"/"+QuestProgress.oskarMax.ToString();
			}
			if(QuestTargetName == "Residenten")
			{
				uppKlarade = QuestProgress.residentenComp.ToString() +"/"+QuestProgress.residentenMax.ToString();
			}
			if(QuestTargetName == "St. Gertrud")
			{
				uppKlarade = QuestProgress.gertrudComp.ToString() +"/"+QuestProgress.gertrudMax.ToString();
			}
			if(QuestTargetName == "St. Knut")
			{
				uppKlarade = QuestProgress.knutComp.ToString() +"/"+QuestProgress.knutMax.ToString();
			}
			if(QuestTargetName == "St. Petri Kyrka")
			{
				uppKlarade = QuestProgress.kyrkanComp.ToString() +"/"+QuestProgress.kyrkanMax.ToString();
			}
			if(QuestTargetName == "Svanen")
			{
				uppKlarade = QuestProgress.svanenComp.ToString() +"/"+QuestProgress.svanenMax.ToString();
			}
			if(QuestTargetName == "Claus Mårtensson")
			{
				uppKlarade = QuestProgress.clausComp.ToString() +"/"+QuestProgress.clausMax.ToString();
			}

            DeselectAll();
            isselected = true;
            image.texture = selected;
			beskrivningsbox.GetComponent<MapText>().SetText(QuestTargetName + " "+ uppKlarade);

		}
	}

    private void DeselectAll() 
    {
        GameObject[] objects = GameObject.FindGameObjectsWithTag("MapButton");

        foreach (GameObject item in objects)
        {
            Map_Button button = item.GetComponent<Map_Button>();
            if (button.Isselected)
            {
                button.Deselect();
            }
        }
    }

    public void Deselect() 
    {
        isselected = false;
        image.texture = notselected;
    }

    bool IsCompleted()
    {
        if (PlayerPrefs.HasKey(QuestTargetName + "C"))
            return PlayerPrefs.GetString(QuestTargetName + "C") == "done";
        return false;
    }

}
