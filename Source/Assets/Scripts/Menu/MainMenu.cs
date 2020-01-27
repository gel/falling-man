using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    public float itemProportionalWidth = 0.3f; // proportional width to screen (0..1) 
    public float itemProportionallHeight = 0.2f; // proportional height to screen (0..1)
    public float itemProportionalSpacing = 0.2f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnGUI()
    {
        float itemWidth = Screen.width * itemProportionalWidth;
        float itemHeight = Screen.height * itemProportionallHeight;
        Rect startNewGame = new Rect();
        Rect exitGame = new Rect();
        int numberOfItems=2;
        
        int menuID = 0;
        startNewGame.x = (Screen.width * (1 - itemProportionalWidth))/2;
        startNewGame.y = (Screen.height * (1 - itemProportionallHeight)) / 2 - itemHeight / numberOfItems + menuID * itemHeight * (1 + itemProportionalSpacing);
        startNewGame.width = itemWidth;
        startNewGame.height = itemHeight;
        if (GUI.Button (startNewGame, "Start New Game")) 
        {
            var sceneManager = GameObject.Find("SceneManager");
            Debug.Log("Loading level 1 menu...");
            sceneManager.GetComponent<Scenes>().GoToLevel(1, "");
        }
        
        menuID = 1;
        exitGame.x = (Screen.width * (1 - itemProportionalWidth)) / 2;
        exitGame.y = (Screen.height * (1 - itemProportionallHeight)) / 2 - itemHeight / numberOfItems + menuID * itemHeight * (1 + itemProportionalSpacing);
        exitGame.width = itemWidth;
        exitGame.height = itemHeight;
        if (GUI.Button (exitGame, "Exit Game")) 
        {
            Debug.Log("Clicked exit!");
            Application.Quit();
        }        
    }
}
