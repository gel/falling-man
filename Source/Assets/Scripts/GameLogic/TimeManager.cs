using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeManager : MonoBehaviour
{
    int countDownSeconds = 5;
    float offsetTimeMessageDelay = 1f;

    private GameObject sceneManager;

    /* Time Handling */
    private float startTime;
    private int restSeconds;
    private int roundedRestSeconds;
    private int displaySeconds;
    private int displayMinutes;

    /* Messages */
    private static int messageID;
    private static bool showMessage;
    private static string messageToShow;


    // Start is called before the first frame update
    void Start()
    {
        messageID = 0;
        showMessage = false;
        sceneManager = GameObject.Find("SceneManager");
        if (sceneManager != null)
        {
            countDownSeconds = sceneManager.GetComponent<Scenes>().GetLevelStartTime();
            Debug.Log("Loaded level's Time: " + countDownSeconds);
        }
        startTime = Time.time;
    }

    void OnGUI()
    {
        //  I need to make sure that my time is based on when 
        //    this script was first called instead of when my game started 
        float guiTime = Time.time - startTime;
        restSeconds = countDownSeconds - (int)guiTime;
        
        if (showMessage)
        {
            GUI.Label(new Rect(Screen.width - 150,13,200,20), messageToShow);
        }
        
        if (restSeconds <= 0)
        {
            sceneManager.GetComponent<Scenes>().FailLevelTime();
        }
        
        if (restSeconds <= 5)
        {
            GUI.Box(new Rect(Screen.width - 120,130,100,30), "Hurry Up!");
        }
        
        //display the timer
        roundedRestSeconds = Mathf.CeilToInt(restSeconds);
        displaySeconds = roundedRestSeconds % 60; 
        displayMinutes = roundedRestSeconds / 60; 
        string text = string.Format ("{0:00}:{1:00}", displayMinutes, displaySeconds); 
        GUI.Box(new Rect(Screen.width - 120,10,100,30), text);
    }

    IEnumerator ShowMessage(string msg, float timeout)
    {
        messageID = messageID + 1;
        int myMessageID = messageID;
        showMessage = true;
        messageToShow = msg;
        yield return new WaitForSeconds(timeout);
        //Debug.Log("my message: " + myMessageID + " global message: " + messageID);
        if (myMessageID == messageID) showMessage=false;
    }

    public void AddOffsetToTime(int offsetInSec)
    {
        countDownSeconds += offsetInSec;
        string msg = offsetInSec.ToString();
        if (offsetInSec > 0) msg = "+" + msg;
        StartCoroutine(ShowMessage(msg, offsetTimeMessageDelay));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
