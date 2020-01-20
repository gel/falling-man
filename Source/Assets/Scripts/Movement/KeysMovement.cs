using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeysMovement : MonoBehaviour
{
    private float speed = 10.0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        var movement = Vector3.zero;

        if (Input.GetKey("w"))
            movement.y++;
        if (Input.GetKey("s"))
            movement.y--;
        if (Input.GetKey("a"))
            movement.x--;
        if (Input.GetKey("d"))
            movement.x++;

        transform.Translate(movement * speed * Time.deltaTime, Space.Self);        
    }
}
