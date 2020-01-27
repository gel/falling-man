﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scenes : MonoBehaviour
{
    static int levelID;
    static int levelSeed; 
    static int levelMapSize;
    static int levelStartTime;
    static string levelMessage;
    static int platformBonus;

    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad (transform.gameObject);
        levelMessage = "";        
    }

    public void GoToMainMenu()
    {
        levelID = 0;
        levelSeed = 0;
        levelMapSize = 0;
        Application.LoadLevel("MainMenu"); 
    }

    public bool IsMainMenu()
    {
        if (levelID == 0) return true;
        else return false;
    }

    /* Level Loading */
    public void GoToLevel(int levelID, string levelMessage) {
        Scenes.levelID = levelID;
        Scenes.levelMessage = levelMessage;
        switch(levelID)
        {
            case 1:
                levelSeed = 1;
                levelMapSize = 50;
                levelStartTime = 10;
                platformBonus = 2;
                break;
            case 2:
                levelSeed = 2;
                levelMapSize = 100;
                levelStartTime = 10;
                platformBonus = 2;
                break;
            case 3:
                levelSeed = 3;
                levelMapSize = 200;
                levelStartTime = 10;
                platformBonus = 1;
                break;
            case 4:
                levelSeed = 30;
                levelMapSize = 400;
                levelStartTime = 10;
                platformBonus = 1;
                break;
            default:
                GoToMainMenu();
                break;
        }
        Application.LoadLevel("Menu"); 
    }

    public void StartLevel() {
        Application.LoadLevel("MainScene"); 
    }

    /* Level Handling */
    public void FailLevelTime()
    {
        GoToLevel(levelID, "Your time is up!");
    }

    public void FailLevelCeiling()
    {
        GoToLevel(levelID, "You didn't escape from the ceiling!");
    }

    public void FailLevelHealth()
    {
        GoToLevel(levelID, "You were killed from the damage!");
    }

    public void CompleteLevel()
    {
        GoToLevel(levelID + 1, "Your completed the level!");
    }

    /* Scene Status*/
    public int GetLevelID()
    {
        return levelID;
    }

    public int GetLevelSeed()
    {
        return levelSeed;
    }

    public int GetLevelMapSize()
    {
        return levelMapSize;
    }

    public int GetLevelStartTime()
    {
        return levelStartTime;
    }

    public string GetLevelMessage()
    {
        return levelMessage;
    }
    
    public int GetPlatformBonus()
    {
        return platformBonus;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
