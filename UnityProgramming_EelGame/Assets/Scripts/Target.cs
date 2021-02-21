using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using System.Runtime.InteropServices.ComTypes;
using UnityEngine;
using UnityEngine.UI;

public class Target : MonoBehaviour
{
    public bool m_isElectricBattery;
    public string m_color;
    public int m_moveSpeed;
    public int m_pointValue;
    public bool m_isBurned;
    public bool m_isSpawned;
    public UnityEngine.Vector3 m_launchLocation;
    public UnityEngine.Vector3 m_startPos;
    public int m_arcHeight;
    public GameObject m_game;
    public GameObject m_level;


    //Hit Method
    //Runs when the Battery is clicked
    //If yes then it checks if the battery is electric 
    //If yes run Blowup
    //If no then it adds the points and decrements the target amount
    //If isnt the correct color then it decreases the total score by the amount of points

    //Returns the points given
    int Hit(string colorWanted)
    {
        int points = 0;
        //Checks if the color is the color wanted
        if (m_color.Equals(colorWanted))
        {
            //Checks if the battery is electric
            if (m_isElectricBattery)
            {
                points=BlowUp();
            }
            else
            {
                points = m_pointValue;
            }
            m_level.GetComponent<Level>().m_batteriesLeft--;
        }
        //Incorrect Color the points for a battery is taken out of the points
        else
        {
            points = -m_pointValue;
        }
        //Destroys Object
        this.gameObject.SetActive(false);
        m_isSpawned = true;
        return points;
    }

    public void setColor(string color)
    {
        m_color = color;
    }

    //Deletes all Batteries on the Screen
    //Returns the points given
    int BlowUp()
    {
        int points;
        //Get the number of batteries and multiply it by the pointValue

        points = 0;
        return points;
    }
    void OnMouseDown()
    {
        m_game.GetComponent<Game>().m_numShots++;
        m_game.GetComponent<Game>().m_levelScore += Hit(m_level.GetComponent<Level>().m_color);
        //Updates Score UI
        //m_game.GetComponent<Game>().UpdateScore();
        Debug.Log("Points: "+m_game.GetComponent<Game>().m_levelScore);
    }

    void SetElectric(bool isElectric)
    {
        m_isElectricBattery = isElectric;
    }

    
    // Start is called before the first frame update
    void Start()
    {
        m_startPos = transform.position;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float nextX = Mathf.MoveTowards(transform.position.x, m_launchLocation.x, m_moveSpeed * Time.deltaTime);

        float nextY = Mathf.Lerp(m_startPos.y, m_launchLocation.y, (nextX - m_startPos.x) / (m_launchLocation.x - m_startPos.x));

        float arc = m_arcHeight * (nextX - m_startPos.x) * (nextX - m_launchLocation.x) / (-0.25f * (m_launchLocation.x - m_startPos.x) * (m_launchLocation.x - m_startPos.x));

        UnityEngine.Vector3 nextLocation = new UnityEngine.Vector3(nextX, nextY+arc,transform.position.z);

        transform.position = nextLocation;
    }
}
