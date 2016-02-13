var menuMsg = "Click the left mouse button to start playing level ";
var exitMsg = "Escape to return to main menu";

private static var sceneManager : GameObject;
private static var levelID : int;
private static var message : String; 
function Awake()
{
	sceneManager = GameObject.Find("SceneManager");
	if (sceneManager == null)		//running scene alone
	{
		levelID=1;
		message = "You have finished the level!";
		message = "You have lost the level!";
	}
	else
	{
		levelID = sceneManager.GetComponent(Scenes).GetLevelID();
		message = sceneManager.GetComponent(Scenes).GetLevelMessage();
	}
}

function Update () {
	if(Input.GetMouseButtonDown(0)){
		Debug.Log("Starting level "+ levelID + "...");
		sceneManager.GetComponent(Scenes).StartLevel();
	}
}

function OnGUI(){
	GUI.Label(Rect(Screen.width/2 - message.length*5/2,Screen.height/8,500,20), message);

	var screenMsg = menuMsg + levelID + "...";
	GUI.Label(Rect(Screen.width/2 -  screenMsg.length*5/2 ,Screen.height/2-20,500,20), screenMsg);
}