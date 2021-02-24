using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Buttons : MonoBehaviour
{
    public GameObject pauseScreen;
    AudioSource audioPlayer;
    public AudioClip paused;
    public GameObject instructionPanel;
    public AudioClip beginMusic;
    public GameObject pauseButtonImage; 

    void Start()
    {
        audioPlayer = GetComponent<AudioSource>();
        instructionPanel.SetActive(true);
        Time.timeScale = 0;
    }

    //When Clicking the Pause 
    public void pauseButton()
    {
        //pause game
        audioPlayer.clip = paused;
        audioPlayer.volume = 0.5f;
        audioPlayer.Play();
        pauseScreen.SetActive(true);
        pauseButtonImage.SetActive(false);
        Time.timeScale = 0;
    }

    public void resumeButton()
    {
        //resume from paused
        pauseScreen.SetActive(false);
        pauseButtonImage.SetActive(true);
        Time.timeScale = 1;
    }

    public void menuButton()
    {
        //go to the main menu
        Time.timeScale = 1;
        SceneManager.LoadScene("MainMenu");
    }

    public void quitButton()
    {
        //quits game
        Application.Quit();
    }

    public void playButton()
    {
        //on MainMenu, Play button to start game. Also the Play Again button after losing
        SceneManager.LoadScene("gameScene");
    }
    public void startGameButton()
    {
        //starts games
        audioPlayer.clip = beginMusic;
        audioPlayer.volume = 1.0f;
        Time.timeScale = 1;
        instructionPanel.SetActive(false);
        audioPlayer.Play();
        pauseButtonImage.SetActive(true);
    }
}
