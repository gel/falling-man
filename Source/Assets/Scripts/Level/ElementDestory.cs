using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElementDestory : MonoBehaviour
{
    private int distanceThreshold;

    // Start is called before the first frame update
    void Start()
    {
        distanceThreshold = -10;
    }

    // Update is called once per frame
    void Update()
    {
        var camera = GameObject.Find("Main Camera");
        if (camera.transform.position.y-transform.position.y < distanceThreshold) 
        {
            Destroy(gameObject);
        }        
    }
}
