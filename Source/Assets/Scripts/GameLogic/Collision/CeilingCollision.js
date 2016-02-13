var CollisionThreshold = 0.1;
var DistanceToCollision = 20;
var shader : Shader;

function Collide()
{
	Debug.Log("Collision with ceiling happened.");
	var sceneManager = GameObject.Find("SceneManager");
	if (sceneManager != null) sceneManager.GetComponent(Scenes).FailLevelCeiling();
}

function ShowWarningToUser(bShowWarning)
{
	//var shader : Shader = Shader.Find("Custom/BrightnessShader");
	if (bShowWarning)
	{
		Camera.main.SetReplacementShader(shader, "");
	}
	else
	{
		Camera.main.ResetReplacementShader();
	}
}

function FixedUpdate()
{
	var camera:GameObject = GameObject.Find("Main Camera");
	if (camera.transform.position.y + CollisionThreshold >= transform.position.y) 
	{
		var sceneManager = GameObject.Find("SceneManager");
		if (sceneManager != null) sceneManager.GetComponent(Scenes).FailLevelCeiling();
	}
	
	if (camera.transform.position.y + DistanceToCollision >= transform.position.y)
	{
		ShowWarningToUser(true);	
	}
	else
	{
		ShowWarningToUser(false);
	}
}