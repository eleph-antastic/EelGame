using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/*Julia Sousa & Luke Driscoll
 * 2345424 // 2344496
 * jsousa@chapman.edu // ldriscoll@chapman.edu
 * CPSC245-01
 * P1 - Target Roast Milestone I
 * Level assets and information is stored here. Also has a method to update variables when level up.
 * */


public class Level : MonoBehaviour
{
    //Stores the current level
    public int m_level;
    //The time it takes to spawn the battery
    public float m_batterySpawnTimer;
    //The time it takes to spawn the attacks
    public float m_attackTimer;
    //The amount of shots taken
    public int m_shots;
    //The color of the level
    public string m_color;
    //The number of batteries needed to complete the level
    public int m_numBatteries;
    //The point multiplier for the level
    public float m_pointMultiplier;
    //The number of batteries left to complete the level
    public float m_batteriesLeft;


    //Modifier for the batteries movement speed
    public float m_batteryMoveSpeedModifier = 1;
    //Modifier for the Attacks movement speed
    public float m_attackMoveSpeedModifier = 1 ;

    //The GameObject for the objective updater
    public GameObject objectiveUpdater;

    //Timer Object/Script accessor
    public GameObject timerObject;

    //Increases the level by modifing most of the attributes by making the spawn timers faster, amount of batteries up and the point multipier more
    public void increaseLevel()
    {
        m_level++;
        m_numBatteries += 2;
        m_batteriesLeft = m_numBatteries;
        m_batterySpawnTimer -= 0.25f;
        m_attackTimer--;
        m_pointMultiplier += 0.1f;
        m_batteryMoveSpeedModifier += 0.01f;
        m_attackMoveSpeedModifier += 0.01f;
        //Updates movespeed
        timerObject.GetComponent<TimerScript>().countdownTime = 60 * (m_level/2) + 20; //Resets timer, gives more time for harder levels

        //Updates Objective and Level texts on screen, pauses game
        objectiveUpdater.GetComponent<objectiveUpdater>().UpdateObjective(m_batteriesLeft, m_numBatteries);
        objectiveUpdater.GetComponent<objectiveUpdater>().UpdateLevel(m_level);
    }
    //Creates the base level
    void Start()
    {
        this.m_shots = 0;
        this.m_batteriesLeft = 5;
        this.m_batteriesLeft = m_numBatteries;
        this.m_level = 1;
        this.m_batterySpawnTimer = 5f;
        this.m_attackTimer = 10f;
        this.m_batteryMoveSpeedModifier = 1;
        this.m_attackMoveSpeedModifier = 1;
        //Updates Objective and Level texts on screen
        objectiveUpdater.GetComponent<objectiveUpdater>().UpdateObjective(m_batteriesLeft, m_numBatteries);
        objectiveUpdater.GetComponent<objectiveUpdater>().UpdateLevel(1);
    }
}
