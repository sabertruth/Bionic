using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LaunchClassScene : MonoBehaviour
{

    //Loads next scene in build que, the choose class scene
    public void LaunchTheClassScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
