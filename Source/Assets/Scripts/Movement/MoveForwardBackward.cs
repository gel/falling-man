using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveForwardBackward : MonoBehaviour
{
    float moveSpeed = 0.02f;
    bool bMoveForward = true;
    static float edgeThreshold = 0.2f;
    int borderSize;
    public bool ToMoveZ = false; 

    // Start is called before the first frame update
    void Start()
    {
        GameObject level = GameObject.Find("Level");
        borderSize = level.GetComponent<GenerateLevel>().xzRange;
    }

    // Update is called once per frame
    void Update()
    {
        float chosenPosition = transform.position.x;
        if (ToMoveZ == true)
            chosenPosition = transform.position.z;

        //Debug.Log("Size of level: " + size);
        //Debug.Log("Move forward: " + bMoveForward);
        //Debug.Log(transform.position.x + " | " + (size - edgeThreshold));
        if (chosenPosition >= (borderSize - edgeThreshold))
        {
            bMoveForward = false;
        }
        else if (chosenPosition <= (-borderSize + edgeThreshold))
        {
            bMoveForward = true;
        }

        Vector3 p = transform.position;
        if (ToMoveZ) 
        {
            if (bMoveForward)
            {
                p.z+= moveSpeed;
            }
            else
            {
                p.z-= moveSpeed;
            }
        }
        else
        {
            if (bMoveForward)
            {
                p.x+= moveSpeed;
            }
            else
            {
                p.x-= moveSpeed;
            }
        }
        transform.position = p;
    }
}
