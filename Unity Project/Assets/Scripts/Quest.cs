using UnityEngine;
using System.Collections;

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
            area.GetComponent<Area>().secondsToDisplay = 3.0f;
            area.GetComponent<Area>().destroyAble = true;
            area.GetComponent<Area>().guiTexture.enabled = true;
            area.GetComponent<Area>().text.text = "Quest completed! Investigated " + targetName;
            Instantiate(area, new Vector3(0.5f, 0.5f, 0), Quaternion.identity);
		}
	}
}
