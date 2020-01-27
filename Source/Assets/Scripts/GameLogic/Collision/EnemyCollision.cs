using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCollision : MonoBehaviour
{
    public int EnemyDamage = 10;

    void Start()
    {
        GetComponent<Renderer>().material.color = Color.red;
    }

    //Detect collisions between the GameObjects with Colliders attached
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag != "Player")
            return;
            
        Debug.Log("Enemy collision logic happened on " + GetInstanceID());
        Destroy (gameObject);
		GameObject world = GameObject.Find("Level");
		HealthManager scoreManager = world.GetComponent<HealthManager>();
		scoreManager.AddOffset(-EnemyDamage);        
    }
}