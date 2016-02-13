/* Example level loader */
var itemPopertionalWidth = 0.3; // proportional width to screen (0..1) 
var itemPopertionalHeight  = 0.2; // proportional height to screen (0..1)
var itemPropertionalSpacing = 0.2;

function OnGUI () {
	var itemWidth = Screen.width*itemPopertionalWidth;
	var itemHeight = Screen.height*itemPopertionalHeight;
	var startNewGame: Rect;
	var exitGame: Rect;
	var numberOfItems=2;
	
	var menuID = 0;
	startNewGame.x = (Screen.width*(1-itemPopertionalWidth))/2;
	startNewGame.y = (Screen.height*(1-itemPopertionalHeight))/2 -itemHeight/numberOfItems + menuID*itemHeight*(1+itemPropertionalSpacing);
	startNewGame.width = itemWidth;
	startNewGame.height = itemHeight;
	if (GUI.Button (startNewGame, "Start New Game")) {
		var sceneManager = GameObject.Find("SceneManager");
		Debug.Log("Loading level 1 menu...");
		sceneManager.GetComponent(Scenes).GoToLevel(1, "");
	}
	
	menuID = 1;
	exitGame.x = (Screen.width*(1-itemPopertionalWidth))/2;
	exitGame.y = (Screen.height*(1-itemPopertionalHeight))/2 -itemHeight/numberOfItems + menuID*itemHeight*(1+itemPropertionalSpacing);
	exitGame.width = itemWidth;
	exitGame.height = itemHeight;
	if (GUI.Button (exitGame, "Exit Game")) {
		Debug.Log("Clicked exit!");
		Application.Quit();
	}

}