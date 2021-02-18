using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Buttons : MonoBehaviour
{
    public GameObject pauseScreen;
    public AudioClip paused;

    //When Clicking the Pause 
    public void pauseButton()
    {
        //pause game
        AudioSource.PlayClipAtPoint(paused, transform.position);
        pauseScreen.SetActive(true);
        Time.timeScale = 0;
    }

    public void resumeButton()
    {
        //resume from paused
        pauseScreen.SetActive(false);
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
}
