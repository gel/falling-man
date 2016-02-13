var reachableDistanceY = 5.0;
var scaleXFactor=2.0;
var scaleZFactor=2.0;

private var bIsReachable = false;
function Update () 
{
	var obj:GameObject = GameObject.Find("Main Camera");
	
	if ( (bIsReachable == false) && (obj.transform.position.y-transform.position.y < reachableDistanceY)) 
	{
		//print("platform is reachable");
		bIsReachable = true;
		//transform.localScale.x= transform.localScale.x*scaleXFactor;
		//transform.localScale.z= transform.localScale.z*scaleZFactor;
	}
}