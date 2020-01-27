using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementManager : MonoBehaviour
{
    public float currentVelocity = 0.0f;
    public int currentComboes = 0;
    public bool jumpingMode = false;
    public bool fallDamageMode = true;
    public float maxFallVelocity = 0.0f;
    public float maxFallThreshold = 0.5f;
    public bool fallDamage = false;
    public float fallDamageStartTime = 0.0f;
    public float fallSeconds = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
        GameObject player = GameObject.FindWithTag("Player");
        CharacterMotor movementScript = player.GetComponent<CharacterMotor>();
        maxFallVelocity = -movementScript.movement.maxFallSpeed;        
    }

    void OnGUI()
    {
        int columnIndex = 30;
        string velocityText = "Velocity: " + currentVelocity.ToString();
        Color velocityColor = Color.white;
        if (fallDamage == true)
        {
            if (fallSeconds < 3 ) velocityColor = new Vector4(0,1,0,1);
            else if (fallSeconds < 6 ) velocityColor = new Vector4(1,1,0,1);
            else velocityColor = new Vector4(1,0,0,1);
        }
        GUI.contentColor = velocityColor;
        GUI.Box(new Rect(columnIndex,10,150,30), velocityText);
        
        var comboesText = "Comboes: " + currentComboes;
        GUI.contentColor = Color.white;
        GUI.Box(new Rect(columnIndex,50,150,30), comboesText);
        
        GUI.contentColor = Color.white;
        string jumpingText;
        if (jumpingMode)
        {
            jumpingText =  "Jumping: Enabled";
        }
        else
        {
            jumpingText = "Jumping: Disabled";
        }
        GUI.Box(new Rect(columnIndex,90,150,30), jumpingText);
        
        string fallDamageText;
        if (fallDamageMode) 
        {
            fallDamageText =  "Fall Damage: Enabled";
        }
        else
        {
            fallDamageText = "Fall Damage: Disabled";
        }
        
        GUI.contentColor = Color.white;
        GUI.Box(new Rect(columnIndex,130,150,30), fallDamageText);
    }

    // Update is called once per frame
    void Update()
    {
        float fallSeconds = Mathf.CeilToInt(Time.time - fallDamageStartTime);
        GameObject player = GameObject.FindWithTag("Player");
        CharacterMotor movementScript = player.GetComponent<CharacterMotor>();
        currentVelocity = movementScript.movement.velocity.y;
        //Debug.Log("Current velocity: " + currentVelocity);
        //Debug.Log("Max velocity: " +  (maxFallVelocity - maxFallThreshold).ToString());
        if (currentVelocity < maxFallVelocity + maxFallThreshold)
        {
            ResetComboes();
            StartFallDamage();
        }        
    }

    public void SetJumpingMode(bool enabled)
    {
        jumpingMode = enabled;
        GameObject player  = GameObject.FindWithTag("Player");
        CharacterMotor movementScript = player.GetComponent<CharacterMotor>();
        movementScript.jumping.enabled = enabled;
    }

    public void SetFallDamageMode(bool enabled)
    {
        fallDamageMode = enabled;
    }

    public void StartFallDamage()
    {
        if (fallDamage == true) 
            return;
        fallDamage = true;
        fallDamageStartTime = Time.time;
    }

    public void StopFallDamage()
    {
        fallDamage = false;
        fallDamageStartTime = 0;
    }

    //TODO: refactor to platformhit
    public void FallDamage(float hitVelocity)
    {
        Combo();
        
        if (fallDamage)
        {
            //Debug.Log("Hit velocity sent: " + hitVelocity.ToString());
            //Debug.Log("Current velocity: " + currentVelocity.ToString());
            int offsetToHealth;
            if (fallSeconds < 3 ) offsetToHealth = -1;
            else if (fallSeconds < 6 ) offsetToHealth = -5;
            else offsetToHealth = -10;
            StopFallDamage();
            if (fallDamageMode) 
                GameObject.Find("Level").GetComponent<HealthManager>().AddOffset(offsetToHealth);
        }
    }

    void Combo()
    {
        currentComboes= currentComboes+1;
    }

    void ResetComboes()
    {
        currentComboes = 0;
    }

}
