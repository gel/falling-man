using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectibleCollision : MonoBehaviour
{
    int CollectibleBonus = 1;

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
        if (collision.gameObject.tag != "Player")
            return;
        
        Debug.Log("Collectible collision logic happened on " + GetInstanceID());

        Destroy (gameObject);
        GameObject world = GameObject.Find("Level");
        ScoreManager scoreManager = world.GetComponent<ScoreManager>();
        scoreManager.AddOffset(CollectibleBonus);
    }    
}
