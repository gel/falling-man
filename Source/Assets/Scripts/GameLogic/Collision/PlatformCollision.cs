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

    //Detect collisions between the GameObjects with Colliders attached
    void OnCollisionEnter(Collision collision)
    {
        if (!enableCollisionLogic) return;
        
        float hitVelocity = collision.relativeVelocity.magnitude;

        enableCollisionLogic = false;
        //Debug.Log("Collision logic happened on " + GetInstanceID());
        GameObject.Find("Level").GetComponent<PlayerMovementManager>().FallDamage(hitVelocity);

        this.GetComponent<Renderer>().material.color = Color.blue;
        GameObject.Find("Level").GetComponent<TimeManager>().AddOffsetToTime(offsetToTime);        
    }
}
