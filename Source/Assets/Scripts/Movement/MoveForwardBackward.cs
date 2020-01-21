using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveForwardBackward : MonoBehaviour
{
    float moveSpeed = 0.02f;
    bool bMoveForward = true;
    static float edgeThreshold = 0.2f;
    int borderSize;

    // Start is called before the first frame update
    void Start()
    {
        GameObject level = GameObject.Find("Level");
        borderSize = level.GetComponent<GenerateLevel>().xzRange;
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log("Size of level: " + size);
        //Debug.Log("Move forward: " + bMoveForward);
        //Debug.Log(transform.position.x + " | " + (size - edgeThreshold));
        if ( transform.position.x >= (borderSize - edgeThreshold) )
        {
            bMoveForward = false;
        }
        else if ( transform.position.x <= (-borderSize + edgeThreshold) )
        {
            bMoveForward = true;
        }
         Vector3 p = transform.position;
        if (bMoveForward)
        {
            p.x+= moveSpeed;
        }
        else
        {
            p.x-= moveSpeed;
        }
        transform.position = p;        
    }
}
