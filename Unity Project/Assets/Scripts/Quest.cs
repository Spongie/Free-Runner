using UnityEngine;
using System.Collections;

public class Quest : MonoBehaviour {

    public string description;
	public string targetName;
    bool completed;
    //asd
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
        get { return "You hace succesfullly investigated " + targetName;}
    }

	void OnCollisionEnter(Collision collision)
	{
		if (collision.gameObject.tag == "Player")
		{
            Debug.Log("Quest completed! Investigated " + targetName);
                completed = true;
            Destroy(GetComponent<BoxCollider>());
		}
	}
}
