using UnityEngine;
using System.Collections;
using System.IO;

public class Quest : MonoBehaviour {

    public string description;
	public string targetName;
    bool completed;
    public GameObject area;
  
    void Start()
    {
        completed = false;
    }

	public bool Completed
    {
        get { return completed; }
    }

    public string CompletedText
    {
        get { return "Uppdag avklarat! Du har undersökt " + targetName;}
    }

	void OnCollisionEnter(Collision collision)
	{
		if (collision.gameObject.tag == "Player")
		{
            Debug.Log("Quest completed! Investigated " + targetName);
            completed = true;
            Destroy(GetComponent<BoxCollider>());
            
            GameObject spawn = Instantiate(area, new Vector3(0.5f, 0.5f, -1), Quaternion.identity) as GameObject;
            Area fromSpawn = spawn.GetComponent<Area>();
            fromSpawn.secondsToDisplay = 3.0f;
            fromSpawn.destroyAble = true;
            fromSpawn.guiTexture.enabled = true;
            fromSpawn.PopUpBackground.enabled = true;
            fromSpawn.GetComponentInChildren<GUIText>().text = "Uppdrag avklarat " + targetName;
            SaveCompleted();
		}
	}

    public void SaveCompleted()
    {
        description = "Avklarad!";
    }
}
