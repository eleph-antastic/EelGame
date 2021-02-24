using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/*Julia Sousa & Luke Driscoll
 * 2345424 // 2344496
 * jsousa@chapman.edu // ldriscoll@chapman.edu
 * CPSC245-01
 * P1 - Target Roast Milestone I
 * A script to update the UI components regarding the objective, score, and level
 * */

public class objectiveUpdater : MonoBehaviour
{

    //UI aspects to update
    //UI object that displays the score
    public Text scoreText;

    //UI object that displays the total amount of batteries that need to be hit and their color
    public Text objectiveTitle;

    //UI object that displays the objective with total batteries hit and batteries left
    public Text objectiveCount;

    //UI object that displays the current level the player is on
    public Text levelText;

    //AudioClip that holds the audio of the level up sound
    public AudioClip levelUpSound;

    //audiosource that plays audio when progressing to next level
    AudioSource audioPlayer;


    // Start is called before the first frame update, sets audiplayer to the audioplayer on the object
    void Start()
    {
        audioPlayer = GetComponent<AudioSource>();
    }

    //Update Objective - updates the objective count on screen
    //Float Batteries Left - receives the amount of batteries remaining for the objective to be completed
    //Float Batteries Total - receives the amount of batteries total that need to be hit for the objective to be completed
    public void UpdateObjective(float batteriesLeft, float batteriesTotal)
    {
        objectiveCount.text = batteriesLeft.ToString() + "/" + batteriesTotal.ToString() + " Batteries Left";
        Debug.Log("changed objective");
    }

    //Update Objective Title - updates the objective line that describes what specific type of battery needs to be hit and how many
    //String Color - the color of the battery that needs to be hit to progress to the next level
    //Float Batteries Total - receives the amount of batteries total that need to be hit for the objective to be completed
    public void UpdateObjectiveTitle (string color, float batteriesTotal)
    {
        objectiveTitle.text = batteriesTotal + " " + color + " Batteries";
        Debug.Log("Updated Objective Title");
    }

    //Update Score - updates the player's total score after hitting a battery
    //int New Score - takes a score int parameter and updates the text to that new amount
    public void UpdateScore(int newScore)
    {
        scoreText.text = "Score " + newScore;
    }

    //Update Level - updates the level number and plays a sound when progressing to a level higher than 1
    //int Level - the level the player is on
    public void UpdateLevel(int level)
    {
        if (level > 1)
        {
            audioPlayer.clip = levelUpSound;
            audioPlayer.Play();
        }
        levelText.text = "Level: " + level.ToString();
        Debug.Log("Updated level");
    }
}
