using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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

    //Modifier for the Attacks movement speed


    //The GameObject for the objective updater
    public GameObject objectiveUpdater;

    //Increases the level by modifing most of the attributes by making the spawn timers faster, amount of batteries up and the point multipier more
    public void increaseLevel()
    {
        m_level++;
        m_numBatteries += 2;
        m_batteriesLeft = m_numBatteries;
        m_batterySpawnTimer -= 0.25f;
        m_attackTimer--;
        m_pointMultiplier += 0.1f;
        //Updates Objective and Level texts on screen
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
        //Updates Objective and Level texts on screen
        objectiveUpdater.GetComponent<objectiveUpdater>().UpdateObjective(m_batteriesLeft, m_numBatteries);
        objectiveUpdater.GetComponent<objectiveUpdater>().UpdateLevel(1);
    }
}
