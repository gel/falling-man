var offsetToTime : int = 2;
var enableCollisionLogic : boolean = true;

function Awake()
{
	var sceneManager = GameObject.Find("SceneManager");
	if (sceneManager != null)
	{
		offsetToTime = sceneManager.GetComponent(Scenes).GetPlatformBonus();
	}
}

function Collide(hitVelocity : float)
{
	if (!enableCollisionLogic) return;
	
	enableCollisionLogic = false;
	//Debug.Log("Collision logic happened on " + GetInstanceID());
	GameObject.Find("Level").GetComponent(PlayerMovementManager).FallDamage(hitVelocity);

	GetComponent.<Renderer>().material.color = Color.blue;
	GameObject.Find("Level").GetComponent(TimeManager).AddOffsetToTime(offsetToTime);
}