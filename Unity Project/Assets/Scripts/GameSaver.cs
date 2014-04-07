using UnityEngine;
using System.Collections;

public class GameSaver : MonoBehaviour {

    public Transform player;

    void Start()
    {
        LoadScene();
    }

    public void SaveScene()
    {
        SavePlayer();
        PlayerPrefs.Save();
    }

    public void LoadScene()
    {
        if (PlayerPrefs.HasKey("xpos"))
            LoadPlayer();
        LoadQuests();
    }

    private void LoadPlayer()
    {
        player.transform.position = new Vector3(PlayerPrefs.GetFloat("xpos"), PlayerPrefs.GetFloat("ypos"), PlayerPrefs.GetFloat("zpos"));
        player.transform.eulerAngles = new Vector3(PlayerPrefs.GetFloat("xRot"), PlayerPrefs.GetFloat("yRot"), PlayerPrefs.GetFloat("zRot"));
    }

    private void SavePlayer()
    {
        SavePlayerPosition();
        SavePlayerRotation();
        SaveQuests();
        
    }

    private void LoadQuests()
    {
        GameObject[] quests = GameObject.FindGameObjectsWithTag("Quest");
        foreach (GameObject item in quests)
        {
            Quest quest = item.GetComponent<Quest>();
            if (PlayerPrefs.GetString(quest.targetName) == "Avklarad!")
            {
                Destroy(quest.GetComponent<BoxCollider>());
                quest.SaveCompleted();
            }
        }
    }
    
    private void SaveQuests()
    {
        GameObject[] quests = GameObject.FindGameObjectsWithTag("Quest");
        foreach (GameObject item in quests)
        {
            Quest quest = item.GetComponent<Quest>();
            if (PlayerPrefs.GetString(quest.targetName) != "Avklarad!")
            {
                PlayerPrefs.SetString(quest.targetName, quest.description);
                Debug.Log("Saved quest with name: " + quest.targetName);
            }
        }
    }

    private void SavePlayerPosition()
    {
        PlayerPrefs.SetFloat("xpos", player.position.x);
        PlayerPrefs.SetFloat("ypos", player.position.y);
        PlayerPrefs.SetFloat("zpos", player.position.z);
        Debug.Log("Saved player position");
    }

    private void SavePlayerRotation()
    {
        PlayerPrefs.SetFloat("xRot", player.eulerAngles.x);
        PlayerPrefs.SetFloat("yRot", player.eulerAngles.y);
        PlayerPrefs.SetFloat("zRot", player.eulerAngles.z);
        Debug.Log("Saving player rotation");
    }
}
