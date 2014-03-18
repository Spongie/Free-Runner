using UnityEngine;
using System.Collections;

public class Quest : MonoBehaviour {

    public string description;
	public string targetName;
    bool completed;
  
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
            Area area = new Area();
            area.secondsToDisplay = 3.0f;
            area.destroyAble = true;
            area.text.text = "Quest completed! Investigated " + targetName;
            Instantiate(area, collision.gameObject.transform.position, Quaternion.identity);
		}
	}
}
