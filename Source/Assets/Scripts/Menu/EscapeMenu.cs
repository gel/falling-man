using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EscapeMenu : MonoBehaviour
{

    float delayInSecBetweenKeyPress=0.001f;

    private bool IsPaused;
    private bool delayPassed;
    GameObject sceneManager;

    // Start is called before the first frame update
    void Start()
    {
        IsPaused = false;
        delayPassed = true;
        sceneManager = GameObject.Find("SceneManager");        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey ("escape") && delayPassed) {
            if (sceneManager.GetComponent<Scenes>().IsMainMenu() == false)
            {
                if (!IsPaused) {
                    IsPaused = true;
                }
                else {
                    IsPaused = false;
                }
                StartCoroutine(StartDelay());
            }
            else
            {
                Application.Quit();
            }
        }        
    }

	IEnumerator StartDelay()
	{
		delayPassed = false;
		yield return new WaitForSeconds(delayInSecBetweenKeyPress);
		delayPassed = true;
	}

	void OnGUI(){
		if (IsPaused){
			GUI.Box(new Rect (0,40,100,80), "");
			
			if (GUI.Button(new Rect (10,60,80,20), "Menu")){
				IsPaused = false;
				Debug.Log("Loading main menu...");
				sceneManager.GetComponent<Scenes>().GoToMainMenu();
			}
			
			// Make the Quit button.
			if (GUI.Button(new Rect (10,90,80,20), "Quit")) {
				Application.Quit();
			}
		}
	}    
}
