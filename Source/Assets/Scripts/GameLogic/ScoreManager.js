static var PlayerScore : int;
var jumpingPowerUpScore : int = 3;
var fallDamagePowerUpScore : int = 6;

function Awake()
{
	PlayerScore = 0;
	var world = GameObject.Find("Level");
	var playerMovementManager = world.GetComponent(PlayerMovementManager);
	playerMovementManager.SetJumpingMode(PlayerScore >= jumpingPowerUpScore);
	playerMovementManager.SetFallDamageMode(PlayerScore < fallDamagePowerUpScore);
}

function OnGUI ()
{
	var text = PlayerScore.ToString();
	GUI.Box (Rect(Screen.width - 120,90,100,30), "Collectibles: " + text);
}

function AddOffset(offset : int)
{
	PlayerScore += offset;
	var world = GameObject.Find("Level");
	var playerMovementManager = world.GetComponent(PlayerMovementManager);
	playerMovementManager.SetJumpingMode(PlayerScore >= jumpingPowerUpScore);
	playerMovementManager.SetFallDamageMode(PlayerScore < fallDamagePowerUpScore);
}