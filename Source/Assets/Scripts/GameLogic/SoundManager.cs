using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public bool bEnableSound = true;
    public bool bEnableMusic = true;
    public AudioClip onLevelStartSound;
    public AudioClip onJumpSound;
    public AudioClip onLandSound;

    // Start is called before the first frame update
    void Start()
    {
        if (bEnableMusic) GetComponent<AudioSource>().PlayOneShot(onLevelStartSound);
    }

    void OnJump() 
    {
        if (bEnableSound) 
            this.GetComponent<AudioSource>().PlayOneShot(onJumpSound);
    }

    void OnLand()
    {
        if (bEnableSound) 
        this.GetComponent<AudioSource>().PlayOneShot(onLandSound);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
