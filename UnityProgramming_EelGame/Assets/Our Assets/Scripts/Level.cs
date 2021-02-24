using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Level : MonoBehaviour
{
    public int m_level;
    public float m_batterySpawnTimer;
    public float m_attackTimer;
    public int m_shots;
    public string m_color;
    public int m_numBatteries;
    public float m_pointMultiplier;
    public float m_batteriesLeft;


    public GameObject objectiveUpdater;


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
