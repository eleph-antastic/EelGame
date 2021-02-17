using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.ComTypes;
using UnityEngine;

public class Target : MonoBehaviour
{
    public bool m_isElectricBattery;
    public string m_color;
    public int m_moveSpeed;
    public int m_pointValue;
    public bool m_isBurned;
    public GameObject game;


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
            //game.m_numBatteries--;
        }
        //Incorrect Color the points for a battery is taken out of the points
        else
        {
            points = -m_pointValue;
        }
        //Destroys Object
        Destroy(this.gameObject);
        return points;
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
        int points = Hit("Blue");
        Debug.Log("Hit");
        Debug.Log("Points: " + points);
    }

    //SetElectric()
    //SetColor()

    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
