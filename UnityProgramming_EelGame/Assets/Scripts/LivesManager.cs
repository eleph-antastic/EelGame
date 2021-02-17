using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LivesManager : MonoBehaviour
{

    public AudioClip deathSound;
    public bool hit = false;
    public int Lives = 3;

    public GameObject life1;
    public GameObject life2;
    public GameObject life3;

    public GameObject loseScreen;

    // Start is called before the first frame update
    void Start()
    {
        
    }
    void Update()
    {
        if (hit == true)
        {
            AudioSource.PlayClipAtPoint(deathSound, transform.position);
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
            life1.SetActive(false);
            loseScreen.SetActive(true);
            Time.timeScale = 0;
        }
    }

}
