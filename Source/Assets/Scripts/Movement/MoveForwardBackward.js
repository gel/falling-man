var moveSpeed = 0.02;
private var bMoveForward = true;
private static var edgeThreshold = 0.2;
private var borderSize : int;

function Start()
{
	borderSize = GameObject.Find("Level").GetComponent(GenerateLevel).xzRange;
}

function Update () {
	//Debug.Log("Size of level: " + size);
	//Debug.Log("Move forward: " + bMoveForward);
	//Debug.Log(transform.position.x + " | " + (size - edgeThreshold));
	if ( transform.position.x >= (borderSize - edgeThreshold) )
	{
		bMoveForward = false;
	}
	else if ( transform.position.x <= (-borderSize + edgeThreshold) )
	{
		bMoveForward = true;
	}

	if (bMoveForward)
	{
		transform.position.x+= moveSpeed;
	}
	else
	{
		transform.position.x-= moveSpeed;
	}
}