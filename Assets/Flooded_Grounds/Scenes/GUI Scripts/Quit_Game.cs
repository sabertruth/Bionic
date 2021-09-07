using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Quit_Game : MonoBehaviour
{

    public void QuitGame()
    {
        Debug.Log("YOU HAVE QUIT THE GAME");
        Application.Quit();
    }

}
