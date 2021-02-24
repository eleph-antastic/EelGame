using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/*Julia Sousa & Luke Driscoll
 * 2345424
 * jsousa@chapman.edu
 * CPSC245-01
 * P1 - Target Roast Milestone I
 * A script to keep track of the time in-game and to stop the game once the timer runs out. 
 * */

public class TimerScript : MonoBehaviour
{
    //Integer holding the seconds left in-game
    public int countdownTime; 

    //Text object displayed on screen with seconds
    public Text countdownDisplay;

    //Life Manager that keeps track of 
    public GameObject livesManager;

    //Start - begins coroutine to countdown timer at scene start
    private void Start()
    {

        StartCoroutine(CountdownTimer());
    }

    //Countdown Timer - Coroutine that counts down seconds and, when the time is at 0, ends game
    IEnumerator CountdownTimer()
    {
        while(countdownTime > 0)
        {
            countdownDisplay.text = countdownTime.ToString();

            yield return new WaitForSeconds(1f);

            countdownTime--;
        }

        countdownDisplay.text = "Time's Up!";

        //LoseScreen needs to be activated and game needs to end
        //sets lives to 0 so you die immediately
        livesManager.GetComponent<LivesManager>().Lives = 0;
        //changes text to be about time up
        livesManager.GetComponent<LivesManager>().timerRanOut = true;
    }
}
