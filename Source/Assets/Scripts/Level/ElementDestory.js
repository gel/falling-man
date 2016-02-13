var distanceThreshold = -10;

function Update () {
	var camera:GameObject = GameObject.Find("Main Camera");
	if (camera.transform.position.y-transform.position.y < distanceThreshold) 
	{
		Destroy(gameObject);
	}
}