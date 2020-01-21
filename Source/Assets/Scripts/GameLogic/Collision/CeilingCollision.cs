using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CeilingCollision : MonoBehaviour
{
    public float CollisionThreshold = 0.1f;
    public int DistanceToCollision = 20;
    public Shader shader;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        GameObject camera = GameObject.Find("Main Camera");
        if (camera.transform.position.y + CollisionThreshold >= transform.position.y) 
        {
            GameObject sceneManager = GameObject.Find("SceneManager");
            if (sceneManager != null) sceneManager.GetComponent<Scenes>().FailLevelCeiling();
        }
        
        if (camera.transform.position.y + DistanceToCollision >= transform.position.y)
        {
            ShowWarningToUser(true);	
        }
        else
        {
            ShowWarningToUser(false);
        }        
    }

    void ShowWarningToUser(bool bShowWarning)
    {
        //var shader : Shader = Shader.Find("Custom/BrightnessShader");
        if (bShowWarning)
        {
            Camera.main.SetReplacementShader(shader, "");
        }
        else
        {
            Camera.main.ResetReplacementShader();
        }
    }


    //Detect collisions between the GameObjects with Colliders attached
    void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Collision with ceiling happened.");
        var sceneManager = GameObject.Find("SceneManager");
        if (sceneManager != null) sceneManager.GetComponent<Scenes>().FailLevelCeiling();     
    }    
}
