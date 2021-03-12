using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    public GameObject game;
    public string attack;
    public bool isSpawned;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(isSpawned)
        {
            //Move the wave across the screen
            this.transform.Translate(0, 0, game.GetComponent<Game>().m_dragonSpeed * Time.deltaTime);
            //Checks if wave is Out of bounds if so deletes it
            if (this.gameObject.transform.position.x >= 1400)
            {
                Destroy(this.gameObject.gameObject);
                isSpawned = false;
                if(attack == "Wave")
                {
                    game.GetComponent<Game>().m_waveSpawned = false;
                }
                else if (attack == "Dragon")
                {
                    game.GetComponent<Game>().m_dragonSpawned = false;
                }
            }
        }
    }
}
