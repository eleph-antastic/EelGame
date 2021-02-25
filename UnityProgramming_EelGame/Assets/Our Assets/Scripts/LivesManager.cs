using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/*Julia Sousa & Luke Driscoll
 * 2345424 // 2344496
 * jsousa@chapman.edu // ldriscoll@chapman.edu
 * CPSC245-01
 * P1 - Target Roast Milestone I
 * A script that holds the functions each button will call when pressed/clicked
 * */

public class LivesManager : MonoBehaviour
{
    //audio clip when player dies
    public AudioClip deathSound;

    //audio clip when player takes damage
    public AudioClip hurtSound;

    //audiosource that plays audio when taking damage and dying
    AudioSource audioPlayer;

    //boolean that gets changed when the player gets hit
    public bool hit = false;

    //int life count
    public int Lives = 3;

    //icon for the first life
    public GameObject life1;

    //icon for the second life
    public GameObject life2;

    //icon for the third life
    public GameObject life3;

    //lost game screen that displays once game ends
    public GameObject loseScreen;

    //pause button object that gets hidden once game is over
    public GameObject pauseButtonImage;

    //Text that displays when you lose. Changes when you die because the timer ran out
    public Text loseMessage;

    //boolean that changes the loseMessage to be focused on the timer running out rather than getting hit and losing all 3 lives
    public bool timerRanOut = false;

    // Start is called before the first frame update, sets audiplayer to the audioplayer on the object
    void Start()
    {
        audioPlayer = GetComponent<AudioSource>();
    }

    //Updates every frame and checks if the player has been hit/taken damage/died
    void Update()
    {
        //If the hit variable has been set to true, removes a life and hides the next life icon
        if (hit == true)
        {
            Debug.Log("damaged");
            audioPlayer.clip = hurtSound;
            audioPlayer.Play();
            Lives -= 1;
            hit = false;
            if (Lives == 2)
            {
                life3.SetActive(false);
            }
            if (Lives == 1)
            {
                life2.SetActive(false);
            }
        }

        //If all lives have ran out, plays death sound and stops the game. Also checks to see if the death was specifically because of the timer running out
        if (Lives == 0)
        {
            audioPlayer.clip = deathSound;
            audioPlayer.Play();
            life3.SetActive(false);
            life2.SetActive(false);
            life1.SetActive(false);
            loseScreen.SetActive(true);
            if (timerRanOut)
            {
                loseMessage.text = "Time's Up! You Lose.";
            }
            pauseButtonImage.SetActive(false);
            Time.timeScale = 0;
            Lives -= 1;
        }
    }

}
