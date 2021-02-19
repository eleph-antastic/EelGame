using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LivesManager : MonoBehaviour
{

    public AudioClip deathSound;
    public AudioClip hurtSound;
    AudioSource audioPlayer;
    public bool hit = false;
    public int Lives = 3;

    public GameObject life1;
    public GameObject life2;
    public GameObject life3;

    public GameObject loseScreen;
    public GameObject pauseButtonImage;
    public Text loseMessage;

    public bool timerRanOut = false;

    // Start is called before the first frame update
    void Start()
    {
        audioPlayer = GetComponent<AudioSource>();
    }
    void Update()
    {
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
