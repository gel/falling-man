using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebugLevelScene : MonoBehaviour
{
    public bool KeepSceneViewActive = false;
    public bool GoToMain = false;
    static bool SetMain = false;
    
    void Start()
    {
        if (this.KeepSceneViewActive && Application.isEditor)
        {
            //UnityEditor.SceneView.FocusWindowIfItsOpen(typeof(UnityEditor.SceneView));
        }

        if (GoToMain == false) 
            return;
        
        if (SetMain == true)
            return;
            
        SetMain = true;
        Application.LoadLevel("MainMenu");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
