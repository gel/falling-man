using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public int PlayerScore;
    public int jumpingPowerUpScore = 3;
    public int fallDamagePowerUpScore = 6;
    
    // Start is called before the first frame update
    void Start()
    {
        PlayerScore = 0;
        var world = GameObject.Find("Level");
        var playerMovementManager = world.GetComponent<PlayerMovementManager>();
        playerMovementManager.SetJumpingMode(PlayerScore >= jumpingPowerUpScore);
        playerMovementManager.SetFallDamageMode(PlayerScore < fallDamagePowerUpScore);        
    }

    void OnGUI ()
    {
        string text = PlayerScore.ToString();
        GUI.Box(new Rect(Screen.width - 120,90,100,30), "Collectibles: " + text);
    }

    public void AddOffset(int offset)
    {
        PlayerScore += offset;
        var world = GameObject.Find("Level");
        var playerMovementManager = world.GetComponent<PlayerMovementManager>();
        playerMovementManager.SetJumpingMode(PlayerScore >= jumpingPowerUpScore);
        playerMovementManager.SetFallDamageMode(PlayerScore < fallDamagePowerUpScore);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
