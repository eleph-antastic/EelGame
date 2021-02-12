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
    public float m_accuracy;
    //The current level
    public int m_currLevel;
    //Amount of eels needed for this level
    public int m_numBatteries;


    //Checks if the number of batteries are gotten
    //Returns true/false depending on if the numBatteries= the parameter
    bool checkForLevelWin(int numBatteries)
    {
        return m_numBatteries >= numBatteries;
    }

    //Sends the wave attack across the screen
    void sendWave()
    {
        //Instantiates a wave object
        //Sends it across the screen
    }

    //Sends the Dragon attack across the screen
    void sendDragon()
    {
        //Instantiates a Dragon object
        //Sends it across the screen
    }

    //Spawns the level of batteries
    void SpawnBattery()
    {
        
    }

    //Shoots the battery in a parabolic movement
    void launchBattery()
    {

    }




    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
