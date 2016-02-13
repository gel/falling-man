var pushPower = 2.0;

function OnCollisionEnter(theCollision : Collision) {
	Debug.Log("Collision happened with: " + theCollision.gameObject.name);
}

function OnControllerColliderHit (hit : ControllerColliderHit) 
{
	var collider : CharacterController = hit.controller;
	var hitVelocity = collider.velocity.y;
	if ( hitVelocity > 5 ) Debug.Log("Collision velocity is: " + collider.velocity.y);
	hit.gameObject.SendMessage("Collide", hitVelocity, SendMessageOptions.DontRequireReceiver);
	/*
	var body : Rigidbody = hit.collider.attachedRigidbody;
	// no rigidbody
	if (body == null || body.isKinematic)
		return;
	*/

}
