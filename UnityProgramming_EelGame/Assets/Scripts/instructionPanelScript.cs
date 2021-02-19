using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class instructionPanelScript : MonoBehaviour
{

    public GameObject instructionPanel;
    public AudioClip beginMusic;

    // Start is called before the first frame update
    void Start()
    {
        instructionPanel.SetActive(true);
        Time.timeScale = 0;
    }
    public void playButton()
    {
        //starts game
        Time.timeScale = 1;
        instructionPanel.SetActive(false);
        AudioSource.PlayClipAtPoint(beginMusic, transform.position);
    }
}
