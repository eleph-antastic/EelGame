using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    public bool isElectricBattery;
    public string color;
    public int moveSpeed;
    public int pointValue;
    public bool isBurned;



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
        if (color.Equals(colorWanted))
        {
            //Checks if the battery is electric
            if (isElectricBattery)
            {
                points=BlowUp();
            }
            else
            {
                points = pointValue;
            }
        }
        else
        {
            points = -pointValue;
        }
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

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
