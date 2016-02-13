var bEnableSound : System.Boolean;
var bEnableMusic : System.Boolean;
var onLevelStartSound : AudioClip;
var onJumpSound : AudioClip;
var onLandSound : AudioClip;

function Start()
{
	if (bEnableMusic) GetComponent.<AudioSource>().PlayOneShot(onLevelStartSound);
}

function OnJump() 
{
	if (bEnableSound) GetComponent.<AudioSource>().PlayOneShot(onJumpSound);
}

function OnLand()
{
	if (bEnableSound) GetComponent.<AudioSource>().PlayOneShot(onLandSound);
}