using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using System.Runtime.InteropServices.ComTypes;
using UnityEngine;
using UnityEngine.UI;

/*Julia Sousa & Luke Driscoll
 * 2345424 // 2344496
 * jsousa@chapman.edu // ldriscoll@chapman.edu
 * CPSC245-01
 * P1 - Target Roast Milestone I
 * Battery script that works with the launching behavior and collection behavior
 * */

public class Target : MonoBehaviour
{
    //Variable to check if the battery is electric or not
    public bool m_isElectricBattery;
    //Color of the battery
    public string m_color;
    //Movement speed of the battery
    public int m_moveSpeed;
    //Point value of the battery
    public int m_pointValue;
    //Checks if the battery is spawned
    public bool m_isSpawned;
    //The location where the battery will be launched
    public UnityEngine.Vector3 m_launchLocation;
    //The start position of the battery
    public UnityEngine.Vector3 m_startPos;
    //The height of the arc of the battery
    public int m_arcHeight;
    //GameObject to store the game manager
    public GameObject m_game;
    //GameObject to store the level manager
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
                Debug.Log("Electric");
                points=BlowUp();
            }
            else
            {
                points = m_pointValue * m_game.GetComponent<Game>().m_pointMultiplier;
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
    //Changes the color of the battery
    public void setColor(string color)
    {
        m_color = color;
    }

    //Deletes all Batteries on the Screen
    //Returns the points given
    int BlowUp()
    {
        int points;
        int batteries = m_game.GetComponent<Game>().blowUpBatteries();
        points = m_pointValue* batteries * m_game.GetComponent<Game>().m_pointMultiplier;
        return points;
    }
    //When the target is clicked increase the shots add points and decrease the amount of batteries left
    void OnMouseDown()
    {
        m_game.GetComponent<Game>().m_numShots++;
        m_game.GetComponent<Game>().m_levelScore += Hit(m_level.GetComponent<Level>().m_color);
        //Updates Score UI
        //m_game.GetComponent<Game>().UpdateScore();
        Debug.Log("Points: "+m_game.GetComponent<Game>().m_levelScore);
    }
    //Changes the battery to electric
    void SetElectric(bool isElectric)
    {
        m_isElectricBattery = isElectric;
    }

    
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //Makes the battery move in the arc
        float nextX = Mathf.MoveTowards(transform.position.x, m_launchLocation.x, m_moveSpeed * Time.deltaTime);

        float nextY = Mathf.Lerp(m_startPos.y, m_launchLocation.y, (nextX - m_startPos.x) / (m_launchLocation.x - m_startPos.x));

        float arc = m_arcHeight * (nextX - m_startPos.x) * (nextX - m_launchLocation.x) / (-0.25f * (m_launchLocation.x - m_startPos.x) * (m_launchLocation.x - m_startPos.x));

        UnityEngine.Vector3 nextLocation = new UnityEngine.Vector3(nextX, nextY+arc,transform.position.z);

        transform.position = nextLocation;
        if(transform.position.y < -700)
        {
            this.gameObject.SetActive(false);
            m_isSpawned = true;
        }
    }
}
