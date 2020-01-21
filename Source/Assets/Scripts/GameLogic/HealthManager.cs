using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthManager : MonoBehaviour
{
    static int PlayerHealth;

    // Start is called before the first frame update
    void Start()
    {
        PlayerHealth = 100;
    }

    void OnGUI ()
    {
        string text = PlayerHealth.ToString() + "%";
        GUI.Box(new Rect(Screen.width - 120,50,100,30), "Health: " + text);
    }

    public void AddOffset(int offset)
    {
        int newPlayerHealth = PlayerHealth + offset;
        if (newPlayerHealth < 0)
        {
            PlayerHealth = 0;
        }
        else
        {
            PlayerHealth = newPlayerHealth;
        }
        
        if (PlayerHealth == 0 )
        {
            var sceneManager = GameObject.Find("SceneManager");
            if (sceneManager != null) sceneManager.GetComponent<Scenes>().FailLevelHealth();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
