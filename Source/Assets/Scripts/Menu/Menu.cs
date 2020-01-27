using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menu : MonoBehaviour
{
    string menuMsg = "Click the left mouse button to start playing level ";
    string exitMsg = "Escape to return to main menu";

    static GameObject sceneManager;
    static int levelID;
    static string message; 

    // Start is called before the first frame update
    void Start()
    {
        sceneManager = GameObject.Find("SceneManager");
        if (sceneManager == null)		//running scene alone
        {
            levelID = 1;
            message = "You have finished the level!";
            message = "You have lost the level!";
        }
        else
        {
            levelID = sceneManager.GetComponent<Scenes>().GetLevelID();
            message = sceneManager.GetComponent<Scenes>().GetLevelMessage();
        }        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("Starting level "+ levelID + "...");
            sceneManager.GetComponent<Scenes>().StartLevel();
        }        
    }

    void OnGUI()
    {
        GUI.Label(new Rect(Screen.width/2 - message.Length*5/2,Screen.height/8,500,20), message);

        string screenMsg = menuMsg + levelID + "...";
        GUI.Label(new Rect(Screen.width/2 -  screenMsg.Length*5/2 ,Screen.height/2-20,500,20), screenMsg);
    }    
}
