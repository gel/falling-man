using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreditsTransition : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
         StartCoroutine("Wait");
    }

    IEnumerator Wait()
    {
        yield return new WaitForSeconds(20);
        Application.LoadLevel("MainMenu");
    }
}
