using UnityEngine;
using System.Collections;
using System.IO;

public class Quest : MonoBehaviour {

    public string description;
	public string targetName;
    bool completed;
    public GameObject area;
    public bool isMain;
	bool display = false;
	float currentTimeElapsed;

    public Texture popupTexture;

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
	void Update()
	{
		if(display)
		{
			currentTimeElapsed += Time.deltaTime;
			if (currentTimeElapsed > 3)
			{
				Destroy(this.gameObject);
			}
		}
	}
    void OnTriggerEnter(Collider collision)
	{
		if (collision.gameObject.tag == "Player")
		{
			display = true;
            /*Debug.Log("Quest completed! Investigated " + targetName);
            completed = true;
            Destroy(GetComponent<BoxCollider>());
            
            GameObject spawn = Instantiate(area, new Vector3(0.5f, 0.5f, -1), Quaternion.identity) as GameObject;
            Area fromSpawn = spawn.GetComponent<Area>();
            fromSpawn.guiTexture.texture = popupTexture;
            fromSpawn.destroyAble = true;
            fromSpawn.guiTexture.enabled = true;
            fromSpawn.PopUpBackground.enabled = true;
            fromSpawn.GetComponentInChildren<GUIText>().text = "Uppdrag avklarat " + targetName;
			Debug.Log ("X: "+fromSpawn.GetComponentInChildren<GUIText>().pixelOffset.x+"Y: "+fromSpawn.GetComponentInChildren<GUIText>().pixelOffset.y);
            */SaveCompleted();
		}
	}
	void OnGui()
	{
		if(display)
			GUI.Label(new Rect (Screen.width/2,0,500,500), "Uppdrag avklarat " + targetName); 
	}
    public void SaveCompleted()
    {
        description = "Avklarad!";
        GameObject.FindGameObjectWithTag("Discovery").GetComponent<DiscoveryBar>().RaiseAwareness();
    }
}
