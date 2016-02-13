
var delayInSecBetweenKeyPress=0.001;

private var IsPaused : System.Boolean;
private var delayPassed;
private var sceneManager : GameObject;

function Awake(){
	IsPaused = false;
	delayPassed = true;
	sceneManager = GameObject.Find("SceneManager");
}

function Update () {
	if (Input.GetKey ("escape") && delayPassed) {
		if (sceneManager.GetComponent(Scenes).IsMainMenu() == false)
		{
			if (!IsPaused) {
				IsPaused = true;
			}
			else {
				IsPaused = false;
			}
			StartDelay();
		}
		else
		{
			Application.Quit();
		}
	}
}

function StartDelay()
{
	delayPassed = false;
	yield WaitForSeconds(delayInSecBetweenKeyPress);
	delayPassed = true;
}

function OnGUI(){
	if (IsPaused){
		GUI.Box (Rect (0,40,100,80), "");
		
		if (GUI.Button (Rect (10,60,80,20), "Menu")){
			IsPaused = false;
			Debug.Log("Loading main menu...");
			sceneManager.GetComponent(Scenes).GoToMainMenu();
		}
		
		// Make the Quit button.
		if (GUI.Button (Rect (10,90,80,20), "Quit")) {
			Application.Quit();
		}
	}
}