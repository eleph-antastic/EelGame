﻿using System.Collections;
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

    public Text levelText;
    public Text objectiveCount;

    public void increaseLevel()
    {
        m_level++;
        levelText.text = "Level: " + m_level;
        m_numBatteries += 2;
        m_batteriesLeft = m_numBatteries;
        m_batterySpawnTimer -= 0.25f;
        m_attackTimer--;
        m_pointMultiplier += 0.1f;
        updateObjective();
    }
    void Start()
    {
        m_shots = 0;
        m_batteriesLeft = 5;
        m_batteriesLeft = m_numBatteries;
        m_level = 1;
        m_batterySpawnTimer = 4f;
        m_attackTimer = 10f;
}
    //When Target is shot correctly, objective count gets updated here
    public void updateObjective()
    {
        objectiveCount.text = m_batteriesLeft + "/" + m_numBatteries + " Batteries Left";
    }

}
