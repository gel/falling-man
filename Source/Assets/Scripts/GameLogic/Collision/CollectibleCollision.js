var CollectibleBonus = 1;

//function Collide()
function OnTriggerEnter(other:Collider)
{
	if (other.gameObject.tag == "Player")
	{
		Destroy (gameObject);
		var world = GameObject.Find("Level");
		var scoreManager = world.GetComponent(ScoreManager);
		scoreManager.AddOffset(CollectibleBonus);
	}
}