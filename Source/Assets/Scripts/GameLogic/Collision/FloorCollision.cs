using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorCollision : MonoBehaviour
{
    int FloorDamage = -1;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //Detect collisions between the GameObjects with Colliders attached
    void OnCollisionEnter(Collision collision)
    {
        float hitVelocity = collision.relativeVelocity.magnitude;
        GameObject.Find("Level").GetComponent<PlayerMovementManager>().FallDamage(hitVelocity);
        GameObject world = GameObject.Find("Level");
        HealthManager healthManager = world.GetComponent<HealthManager>();
        healthManager.AddOffset(FloorDamage);      
    }    
}
