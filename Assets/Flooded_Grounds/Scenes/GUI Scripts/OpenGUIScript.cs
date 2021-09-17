using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OpenGUIScript : MonoBehaviour
{
  
    void Start()
    {
        
    }

    // Open GUI scenes according to input manager 
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.K))
        {
            SceneManager.LoadScene("Killstreak Scene");
        }

        if (Input.GetKeyDown(KeyCode.J))
        {
        }

    }
}
