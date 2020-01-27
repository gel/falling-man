using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformCollision : MonoBehaviour
{
    int offsetToTime = 2;
    bool enableCollisionLogic = true;

    // Start is called before the first frame update
    void Start()
    {
        var sceneManager = GameObject.Find("SceneManager");
        if (sceneManager != null)
        {
            offsetToTime = sceneManager.GetComponent<Scenes>().GetPlatformBonus();
        }        
    }

    void OnTriggerEnter() 
    {
        //Debug.Log("Trigger logic happened on " + GetInstanceID());
        //this.GetComponent<Renderer>().material.color = Color.yellow;
    }

    //Detect collisions between the GameObjects with Colliders attached
    void OnCollisionEnter(Collision collision)
    {
        if (!enableCollisionLogic)
            return;
                
        if (collision.gameObject.tag != "Player")
            return;
        
        Debug.Log("Platform collision logic happened on " + GetInstanceID());

        float hitVelocity = collision.relativeVelocity.magnitude;

        enableCollisionLogic = false;
        
        GameObject.Find("Level").GetComponent<PlayerMovementManager>().FallDamage(hitVelocity);

        this.GetComponent<Renderer>().material.color = Color.blue;
        GameObject.Find("Level").GetComponent<TimeManager>().AddOffsetToTime(offsetToTime);        
    }
}
