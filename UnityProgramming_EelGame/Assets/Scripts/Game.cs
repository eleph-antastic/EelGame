using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour
{
    //Class to deal with spawning the Batteries
    //Dealing with the point calculation
    //And spawning the attacks

    //Score for the level
    public int m_levelScore;

    //Point multiplier for the level
    public int m_pointMultiplier;

    //Time between each attack
    public float m_attackTimer;

    //Time between each battery
    public float m_batteryTimer;

    //The percentage accuracy changes to total amount of points
    private float m_accuracy;

    //The current level
    public int m_currLevel;

    //Amount of batteries needed for this level
    public int m_numBatteries;

    //Number of Shots used in a level
    private int m_numShots;

    //GameObject for Wave
    public GameObject m_wave;

    //The Speed of the wave
    public int m_waveSpeed;

    //GameObject for Dragon
    public GameObject m_dragon;

    //The Speed of the dragon
    public int m_dragonSpeed;

    private bool m_waveSpawned = false;

    private GameObject wave;

    private bool m_dragonSpawned = false;

    private GameObject dragon;

    //Pooling
    public List<GameObject> pooledObjects;
    public GameObject objectToPool;
    public int amountToPool;




    //Checks if the number of batteries are gotten
    //Returns true/false depending on if the numBatteries= the parameter
    bool checkForLevelWin(int numBatteries)
    {
        return m_numBatteries >= numBatteries;
    }

    //Sends the wave attack across the screen
    void sendWave()
    {
        if(m_currLevel>=2)
        {
            //Instantiates a wave object
            Vector3 pos = new Vector3(-1100, -400, -100);
            wave = Instantiate(m_wave, pos, m_wave.transform.rotation);
            //Sends it across the screen
            m_waveSpawned = true;
        }

    }

    //Sends the Dragon attack across the screen
    void sendDragon()
    {
        if (m_currLevel >= 3)
        {
            //Instantiates a dragon object
            Vector3 pos = new Vector3(-1100, -200, -100);
            dragon = Instantiate(m_dragon, pos, m_wave.transform.rotation);
            //Sends it across the screen
            m_dragonSpawned = true;

        }
    }
    //Spawns the level of batteries
    //OR Spawns a battery with a random color
    void SpawnBattery()
    {
        //Spawns all 5 colors of Batteries below the screen
        //Or spawns one battery of a random color
    }

    //Shoots the battery in a parabolic movement
    void launchBattery()
    {
        //Launches battery
    }

    //Respawns all Dead Batteries
    void respawnBatteries()
    {
        //After cycle check each color of battery to see if they are dead
        //If the battery is dead respawn it
    }

    //After the round is over check how many shots it took to shoot the batteries
    //Accuracy is batteries/shots
    float calcAccuracy()
    {
        return (float)m_numBatteries/m_numShots;
    }

    //Starts new level making shots 0 and changing the num batteries, timers and the point multiplier 
    void startNewLevel()
    {
        //Pooling idea
        // Get amount to win
        //The amount to pool is the number of colored batteries times the amount to win
        // Meaning if you need 6 red batteries and there are 6 colors the pool will have 36 batteries
        //This means we will need 6 loops one for each color
        //Also while creating the pools we need to add in the chance for the electric battery




        //Make Pool of Objects
        pooledObjects = new List<GameObject>();
        GameObject tmp;
        for (int i = 0; i < amountToPool; ++i)
        {
            tmp = Instantiate(objectToPool);
            tmp.SetActive(false);
            pooledObjects.Add(tmp);
        }
        //Amount of Pooled objects is numColors*numBatteries

    }

    public GameObject GetPooledObject()
    {
        for(int i=0; i < amountToPool; ++i)
        {
            if(!pooledObjects[i].activeInHierarchy)
            {
                return pooledObjects[i];
            }
        }
        return null;
    }



    // Start is called before the first frame update
    void Start()
    {
        

        sendWave();
        sendDragon();
    }

    // Update is called once per frame
    void Update()
    {
        if(m_waveSpawned)
        {
            //Move the wave across the screen
            wave.transform.Translate(m_waveSpeed * Time.deltaTime, 0, 0);
            //Checks if wave is Out of bounds if so deletes it
            if (wave.transform.position.x >= 1100)
            {
                Destroy(wave);
                m_waveSpawned = false;
            }
        }
        if (m_dragonSpawned)
        {
            //Move the wave across the screen
            dragon.transform.Translate(m_dragonSpeed * Time.deltaTime, 0, 0);
            //Checks if wave is Out of bounds if so deletes it
            if (dragon.transform.position.x >= 1100)
            {
                Destroy(dragon);
                m_dragonSpawned = false;
            }
        }
    }
}
