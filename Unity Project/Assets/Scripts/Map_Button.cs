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
            DeselectAll();
            isselected = true;
            image.texture = selected;
            beskrivningsbox.GetComponent<MapText>().SetText(PlayerPrefs.GetString(QuestTargetName));
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
