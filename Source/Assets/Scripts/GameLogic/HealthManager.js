static var PlayerHealth : int;

function Awake()
{
	PlayerHealth = 100;
}

function OnGUI ()
{
	var text = PlayerHealth.ToString() + "%";
	GUI.Box(Rect(Screen.width - 120,50,100,30), "Health: " + text);
}

function AddOffset(offset : int)
{
	var newPlayerHealth = PlayerHealth + offset;
	if ( newPlayerHealth < 0 )
	{
		PlayerHealth = 0;
	}
	else
	{
		PlayerHealth = newPlayerHealth;
	}
	
	if (PlayerHealth == 0 )
	{
		var sceneManager = GameObject.Find("SceneManager");
		if (sceneManager != null) sceneManager.GetComponent(Scenes).FailLevelHealth();
	}
}