using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LivesManager : MonoBehaviour
{

    public GameObject canvasHUD;
    public AudioClip deathSound;
    public bool hit = false;
    public int Lives = 3;

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
        }
        if (Lives == 0)
        {

        }
    }

}
