using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/*Julia Sousa & Luke Driscoll
 * 2345424 // 2344496
 * jsousa@chapman.edu // ldriscoll@chapman.edu
 * CPSC245-01
 * P1 - Target Roast Milestone I
 * A script that holds the functions each button will call when pressed/clicked
 * */


public class Buttons : MonoBehaviour
{
    //the screen that activates when the game is paused
    public GameObject pauseScreen;

    //audiosource that plays audio when pausing and playing the game
    AudioSource audioPlayer;

    //audio clip when game gets paused
    public AudioClip paused;

    //instruction panel that displays before the game begins
    public GameObject instructionPanel;

    //audio clip that plays when the game begins
    public AudioClip beginMusic;

    //the pause button itself that disappears once the game is already paused or before it starts
    public GameObject pauseButtonImage; 

    //Freezes the game to display instruction panel before the game starts
    void Start()
    {
        audioPlayer = GetComponent<AudioSource>();
        instructionPanel.SetActive(true);
        Time.timeScale = 0;
    }

    //When Clicking the Pause button, plays pause music and stops the game
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

    //Hides the pause button and continues the game
    public void resumeButton()
    {
        //resume from paused
        pauseScreen.SetActive(false);
        pauseButtonImage.SetActive(true);
        Time.timeScale = 1;
    }

    //returns to main menu and changes scenes
    public void menuButton()
    {
        //go to the main menu
        Time.timeScale = 1;
        SceneManager.LoadScene("MainMenu");
    }

    //Quits game
    public void quitButton()
    {
        //quits game
        Application.Quit();
    }

    //on MainMenu, Play button to start game. Also the Play Again button after losing
    public void playButton()
    {
        SceneManager.LoadScene("gameScene");
    }

    //Starts game from start-up. Plays start sound and hides instruction panel
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
