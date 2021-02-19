using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerScript : MonoBehaviour
{
    public int countdownTime;
    public Text countdownDisplay;
    public GameObject livesManager;

    private void Start()
    {

        StartCoroutine(CountdownTimer());
    }

    IEnumerator CountdownTimer()
    {
        while(countdownTime > 0)
        {
            countdownDisplay.text = countdownTime.ToString();

            yield return new WaitForSeconds(1f);

            countdownTime--;
        }

        countdownDisplay.text = "Time's Up!";

        //LoseScreen needs to be activated
        livesManager.GetComponent<LivesManager>().Lives = 0; //sets lives to 0 so you die immediately
        livesManager.GetComponent<LivesManager>().timerRanOut = true; //changes text to be about time up

        //countdownDisplay.gameObject.SetActive(false);
    }
}
