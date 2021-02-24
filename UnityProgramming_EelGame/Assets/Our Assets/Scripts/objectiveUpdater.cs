using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class objectiveUpdater : MonoBehaviour
{

    //UI aspects to update
    public Text scoreText;
    public Text objectiveTitle;
    public Text objectiveCount;
    public Text levelText;

    public AudioClip levelUpSound;
    AudioSource audioPlayer;


    // Start is called before the first frame update
    void Start()
    {
        audioPlayer = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
   
    }

    public void UpdateObjective(float batteriesLeft, float batteriesTotal)
    {
        objectiveCount.text = batteriesLeft.ToString() + "/" + batteriesTotal.ToString() + " Batteries Left";
        Debug.Log("changed objective");
    }

    public void UpdateObjectiveTitle (string color, float batteriesTotal)
    {
        objectiveTitle.text = batteriesTotal + " " + color + " Batteries";
        Debug.Log("Updated Objective Title");
    }

    public void UpdateScore(int newScore)
    {
        scoreText.text = "Score " + newScore;
    }
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
