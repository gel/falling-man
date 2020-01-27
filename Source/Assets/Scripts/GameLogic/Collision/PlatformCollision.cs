using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformCollision : MonoBehaviour
{
    int offsetToTime = 2;
    bool enableCollisionLogic = true;
    GameObject sceneManager;

    // Start is called before the first frame update
    void Start()
    {
        sceneManager = GameObject.Find("SceneManager");
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
        
        Debug.Log("Platform collision logic happened on ID: " + GetInstanceID() + " y: " + transform.position.y);
        enableCollisionLogic = false;

        if (this.GetComponent<Renderer>().material.color == Color.green) // hack
        {
            if (sceneManager != null) 
            {
                sceneManager.GetComponent<Scenes>().CompleteLevel();
            }
        }

        float hitVelocity = collision.relativeVelocity.magnitude;
        GameObject.Find("Level").GetComponent<PlayerMovementManager>().FallDamage(hitVelocity);
        this.GetComponent<Renderer>().material.color = Color.blue;
        GameObject.Find("Level").GetComponent<TimeManager>().AddOffsetToTime(offsetToTime);        
    }
}
