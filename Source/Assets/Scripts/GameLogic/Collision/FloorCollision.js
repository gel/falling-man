var FloorDamage = -1;

function Collide(hitVelocity)
{
	GameObject.Find("Level").GetComponent(PlayerMovementManager).FallDamage(hitVelocity);
	var world = GameObject.Find("Level");
	var healthManager = world.GetComponent(HealthManager);
	healthManager.AddOffset(FloorDamage);
}