var EnemyDamage = 10;

function Awake()
{
	GetComponent.<Renderer>().material.color = Color.red;
}

//function Collide()
function OnTriggerEnter(other:Collider)
{
	if (other.gameObject.tag == "Player")
	{
		Destroy (gameObject);
		var world = GameObject.Find("Level");
		var scoreManager = world.GetComponent(HealthManager);
		scoreManager.AddOffset(-EnemyDamage);
	}
}