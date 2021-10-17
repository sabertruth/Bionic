using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreBoard: MonoBehaviour
{
    [SerializeField] Text scoreText;
    private int currentScore;

    //Retrieve 'score' variable from gunshoot script 
    public void UpdateScore(int score)
    {
        currentScore += score;

        //Scoreboard UI updated according to the score variable
        scoreText.text = currentScore.ToString ("0");
    }
}
