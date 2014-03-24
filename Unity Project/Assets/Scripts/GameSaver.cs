using UnityEngine;
using System.Collections;

public class GameSaver : MonoBehaviour {

    Transform player;

    void SaveScene()
    {
        SavePlayer();  
    }

    private void LoadScene()
    {

    }

    private void SavePlayer()
    {
        SavePlayerPosition();
        SavePlayerRotation();
        SaveQuests();
    }

    private void SaveQuests()
    {
        GameObject[] quests = GameObject.FindGameObjectsWithTag("Quest");
        foreach (GameObject item in quests)
        {
            Quest quest = item.GetComponent<Quest>();
            PlayerPrefs.SetString(quest.targetName, quest.description);
        }
    }

    private void SavePlayerPosition()
    {
        PlayerPrefs.SetFloat("xpos", player.position.x);
        PlayerPrefs.SetFloat("ypos", player.position.y);
        PlayerPrefs.SetFloat("zpos", player.position.z);
    }

    private void SavePlayerRotation()
    {
        PlayerPrefs.SetFloat("xRot", player.rotation.x);
        PlayerPrefs.SetFloat("yRot", player.rotation.y);
        PlayerPrefs.SetFloat("zRot", player.rotation.z);
    }
}
