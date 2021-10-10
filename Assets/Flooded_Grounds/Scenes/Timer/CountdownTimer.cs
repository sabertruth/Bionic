using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CountdownTimer : MonoBehaviour
{   
    //Variables for time
    float currentTime = 0f;
    //Sets timer to be 5 minutes
    float startingTime = 300f;

    [SerializeField] Text TimerText;

    void Start()
        {
            currentTime = startingTime;
        }

    //Adjusts timer so it is not measured per frame
    //Prints current time as whole number
    void Update()
    {
        currentTime -= 1 * Time.deltaTime;
        TimerText.text = currentTime.ToString ("0");

    //Prevent time from going into the negatives
        if (currentTime <=0)
            {
                currentTime = 0;
            }
    }
}
