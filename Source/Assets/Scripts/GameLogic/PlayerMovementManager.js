private static var currentVelocity = 0.0;
private static var currentComboes = 0;
private static var jumpingMode = false;
private static var fallDamageMode = true;
private static var maxFallVelocity = 0.0;
private static var maxFallThreshold = 0.5;
private static var fallDamage = false;
private static var fallDamageStartTime = 0.0;
private static var fallSeconds = 0.0;

function Start()
{
	var player : GameObject = GameObject.FindWithTag("Player");
	var movementScript : CharacterMotor = player.GetComponent(CharacterMotor);
	maxFallVelocity = -movementScript.movement.maxFallSpeed;
}

function OnGUI()
{
	var columnIndex = 30;
	var velocityText = "Velocity: " + currentVelocity.ToString();
	var velocityColor : Color = Color.white;
	if (fallDamage == true)
	{
		if (fallSeconds < 3 ) velocityColor = Vector4(0,1,0,1);
		else if (fallSeconds < 6 ) velocityColor = Vector4(1,1,0,1);
		else velocityColor = Vector4(1,0,0,1);
	}
	GUI.contentColor = velocityColor;
	GUI.Box(Rect(columnIndex,10,150,30), velocityText);
	
	
	var comboesText = "Comboes: " + currentComboes;
	GUI.contentColor = Color.white;
	GUI.Box(Rect(columnIndex,50,150,30), comboesText);
	
	GUI.contentColor = Color.white;
	var jumpingText : String;
	if (jumpingMode) {
		jumpingText =  "Jumping: Enabled";
	}
	else
	{
		jumpingText = "Jumping: Disabled";
	}
	GUI.Box(Rect(columnIndex,90,150,30), jumpingText);
	
	var fallDamageText : String;
	if (fallDamageMode) {
		fallDamageText =  "Fall Damage: Enabled";
	}
	else
	{
		fallDamageText = "Fall Damage: Disabled";
	}
	
	GUI.contentColor = Color.white;
	GUI.Box(Rect(columnIndex,130,150,30), fallDamageText);
}

function Update() 
{
	fallSeconds = Mathf.CeilToInt(Time.time - fallDamageStartTime);
	var player : GameObject = GameObject.FindWithTag("Player");
	var movementScript : CharacterMotor = player.GetComponent(CharacterMotor);
	currentVelocity = movementScript.movement.velocity.y;
	//Debug.Log("Current velocity: " + currentVelocity);
	//Debug.Log("Max velocity: " +  (maxFallVelocity - maxFallThreshold).ToString());
	if (currentVelocity < maxFallVelocity + maxFallThreshold)
	{
		ResetComboes();
		StartFallDamage();
	}
}

function SetJumpingMode(enabled)
{
	jumpingMode = enabled;
	var player : GameObject = GameObject.FindWithTag("Player");
	var movementScript : CharacterMotor = player.GetComponent(CharacterMotor);
	movementScript.jumping.enabled = enabled;
}

function SetFallDamageMode(enabled)
{
	fallDamageMode = enabled;
}


function StartFallDamage()
{
	if (fallDamage == true) return;
	fallDamage = true;
	fallDamageStartTime = Time.time;
}

function StopFallDamage()
{
	fallDamage = false;
	fallDamageStartTime = 0;
}

//TODO: refactor to platformhit
function FallDamage(hitVelocity)
{
	Combo();
	
	if (fallDamage)
	{
		//Debug.Log("Hit velocity sent: " + hitVelocity.ToString());
		//Debug.Log("Current velocity: " + currentVelocity.ToString());
		var offsetToHealth;
		if (fallSeconds < 3 ) offsetToHealth = -1;
		else if (fallSeconds < 6 ) offsetToHealth = -5;
		else offsetToHealth = -10;
		StopFallDamage();
		if (fallDamageMode) GameObject.Find("Level").GetComponent(HealthManager).AddOffset(offsetToHealth);
	}
}

function Combo()
{
	currentComboes= currentComboes+1;
}

function ResetComboes()
{
	currentComboes = 0;
}