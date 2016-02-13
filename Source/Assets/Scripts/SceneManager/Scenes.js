static var levelID : int;
static var levelSeed : int; 
static var levelMapSize : int;
static var levelStartTime : int;
static var levelMessage;
static var platformBonus : int;

function Awake() {
	DontDestroyOnLoad (transform.gameObject);
	levelMessage = "";
}

function GoToMainMenu()
{
	levelID = 0;
	levelSeed = 0;
	levelMapSize = 0;
	Application.LoadLevel("MainMenu"); 
}

function IsMainMenu()
{
	if (levelID == 0) return true;
	else return false;
}

/* Level Loading */
function GoToLevel(levelID, levelMessage) {
	this.levelID = levelID;
	this.levelMessage = levelMessage;
	switch(levelID)
	{
		case 1:
			levelSeed = 1;
			levelMapSize = 700;
			levelStartTime = 10;
			platformBonus = 2;
			break;
		case 2:
			levelSeed = 2;
			levelMapSize = 1000;
			levelStartTime = 10;
			platformBonus = 2;
			break;
		case 3:
			levelSeed = 3;
			levelMapSize = 1300;
			levelStartTime = 10;
			platformBonus = 1;
			break;
		case 4:
			levelSeed = 30;
			levelMapSize = 2000;
			levelStartTime = 10;
			platformBonus = 1;
			break;
		default:
			GoToMainMenu();
			break;
	}
	Application.LoadLevel("Menu"); 
}

function StartLevel() {
	Application.LoadLevel("MainScene"); 
}

/* Level Handling */
function FailLevelTime()
{
	GoToLevel(levelID, "Your time is up!");
}

function FailLevelCeiling()
{
	GoToLevel(levelID, "You didn't escape from the ceiling!");
}

function FailLevelHealth()
{
	GoToLevel(levelID, "You were killed from the damage!");
}


function CompleteLevel()
{
	GoToLevel(levelID+1, "Your completed the level!");
}

/* Scene Status*/
function GetLevelID()
{
	return levelID;
}
function GetLevelSeed()
{
	return levelSeed;
}
function GetLevelMapSize()
{
	return levelMapSize;
}
function GetLevelStartTime()
{
	return levelStartTime;
}
function GetLevelMessage()
{
	return levelMessage;
}
function GetPlatformBonus()
{
	return platformBonus;
}
