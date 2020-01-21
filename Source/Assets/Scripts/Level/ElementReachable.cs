using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElementReachable : MonoBehaviour
{
    public float reachableDistanceY = 5.0f;
    public float scaleXFactor = 2.0f;
    public float scaleZFactor = 2.0f;

    private bool bIsReachable = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        GameObject obj = GameObject.Find("Main Camera");
        
        if ((bIsReachable == false) && (obj.transform.position.y - transform.position.y < reachableDistanceY)) 
        {
            //print("platform is reachable");
            bIsReachable = true;
            //transform.localScale.x= transform.localScale.x*scaleXFactor;
            //transform.localScale.z= transform.localScale.z*scaleZFactor;
        }        
    }
}
