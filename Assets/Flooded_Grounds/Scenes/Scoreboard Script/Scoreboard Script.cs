using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreboardScript : MonoBehaviour
{
    //Variable For score
    int currentScore = 0;
   
 
    [SerializeField] Text ScoreText;

    //Score is updated with 25 points, which is displayed on scoreboard UI
    void Update()
    {
        currentScore = currentScore + 25;
        ScoreText.text = currentScore.ToString("0");
    }
}
