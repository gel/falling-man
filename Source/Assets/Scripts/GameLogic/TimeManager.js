var countDownSeconds : int = 5;
var offsetTimeMessageDelay : float= 1;

private var sceneManager : GameObject;
/* Time Handling */
private var startTime : float;
private var restSeconds : int;
private var roundedRestSeconds : int;
private var displaySeconds : int;
private var displayMinutes : int;

/* Messages */
private static var messageID : int;
private static var showMessage : boolean;
private static var messageToShow : String;

function Awake()
{
	messageID = 0;
	showMessage = false;
	 sceneManager = GameObject.Find("SceneManager");
	if (sceneManager != null)
	{
		countDownSeconds = sceneManager.GetComponent(Scenes).GetLevelStartTime();
		Debug.Log("Loaded level's Time: " + countDownSeconds);
	}
	startTime = Time.time;
}

function OnGUI ()
{
	//  I need to make sure that my time is based on when this script was first called
	//instead of when my game started 
	var guiTime : float = Time.time - startTime;
	restSeconds = countDownSeconds - (guiTime);
	
	if (showMessage)
	{
		GUI.Label(Rect(Screen.width - 150,13,200,20), messageToShow);
	}
	
	if (restSeconds <= 0)
	{
		sceneManager.GetComponent(Scenes).FailLevelTime();
	}
	
	if (restSeconds <= 5)
	{
		GUI.Box (Rect(Screen.width - 120,130,100,30), "Hurry Up!");
	}
	
	//display the timer
	roundedRestSeconds = Mathf.CeilToInt(restSeconds);
	displaySeconds = roundedRestSeconds % 60; 
	displayMinutes = roundedRestSeconds / 60; 
	var text : String = String.Format ("{0:00}:{1:00}", displayMinutes, displaySeconds); 
	GUI.Box (Rect(Screen.width - 120,10,100,30), text);
}

function ShowMessage(msg, timeout : int)
{
	messageID = messageID + 1;
	var myMessageID = messageID;
	showMessage=true;
	messageToShow = msg;
	yield WaitForSeconds(timeout);
	//Debug.Log("my message: " + myMessageID + " global message: " + messageID);
	if (myMessageID == messageID) showMessage=false;
}

function AddOffsetToTime(offsetInSec : int)
{
	countDownSeconds += offsetInSec;
	var msg = offsetInSec.ToString();
	if (offsetInSec > 0) msg = "+" + msg;
	ShowMessage(msg, offsetTimeMessageDelay);
}