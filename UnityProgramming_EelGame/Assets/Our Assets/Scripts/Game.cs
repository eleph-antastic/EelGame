using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


/*Julia Sousa & Luke Driscoll
 * 2345424 // 2344496
 * jsousa@chapman.edu // ldriscoll@chapman.edu
 * CPSC245-01
 * P1 - Target Roast Milestone I
 * The main game script. Runs Update and manages level progression, attack launching, and pooling for batteries.
 * */

public class Game : MonoBehaviour
{
    //Class to deal with spawning the Batteries
    //Dealing with the point calculation
    //And spawning the attacks

    //Score for the game
    public int m_levelScore;

    //Point multiplier for the game
    public int m_pointMultiplier;

    //The percentage accuracy changes to total amount of points
    private float m_accuracy;

    //The current level
    public int m_currLevel;

    //Amount of batteries needed for this level
    public int m_numBatteries;

    //Number of Shots used in a level
    public int m_numShots = 0;

    //GameObject for Wave
    public GameObject m_wave;

    //The Speed of the wave
    public float m_waveSpeed = 900f;

    //GameObject for Dragon
    public GameObject m_dragon;

    //The Speed of the dragon
    public float m_dragonSpeed = 900f;

    //Boolean to see if the wave is spawned or no
    public bool m_waveSpawned = false;

    //GameObject to hold the instantiated wave
    private GameObject wave;

    //Boolean to see if the dragon is spawned or no
    public bool m_dragonSpawned = false;

    //GameObject to hold the instantiated dragon
    private GameObject dragon;

    //GameObject to store the levelmanager
    public GameObject m_level;

    //GameObject to store the livesmanager
    public GameObject m_livesManager;

    //Batterys spawned per wave

    public int batteriesPerWave;


    //List that is the pool of the batterys
    public List<GameObject> pooledObjects;

    //List that is the pool of the bonus batterys
    public List<GameObject> bonusPooledObjects;

    //List that is the pool of the electric batterys
    public List<GameObject> electricPooledObjects;

    //GameObject for the Red Battery
    public GameObject redBattery;

    //GameObject for the Blue Battery
    public GameObject blueBattery;

    //GameObject for the Green Battery
    public GameObject greenBattery;

    //GameObject for the Yellow Battery
    public GameObject yellowBattery;

    //GameObject for the Purple Battery
    public GameObject purpleBattery;

    //GameObject for the Bonus Battery
    public GameObject bonusBattery;
    //GameObject for the Electric Battery
    public GameObject electricBattery;
    //The amount of batteries to be pooled
    public int amountToPool;


    //GameObject that handles changing the text of score & objective
    public GameObject objectiveUpdating;

    //bonus level text display
    public GameObject bonusLevelText;

    //Sends the wave attack across the screen
    void sendWave()
    {
        
        //Instantiates a wave object
        Vector3 pos = new Vector3(-1100, -400, -100);
        wave = Instantiate(m_wave, pos, m_wave.transform.rotation);
        wave.GetComponent<Attack>().isSpawned = true;
        //Sends it across the screen
        m_waveSpawned = true;

    }

    //Sends the Dragon attack across the screen
    void sendDragon()
    {
        //Instantiates a dragon object
        Vector3 pos = new Vector3(-1100, -200, -100);
        dragon = Instantiate(m_dragon, pos, m_wave.transform.rotation);
        dragon.GetComponent<Attack>().isSpawned = true;
        //Sends it across the screen
        m_dragonSpawned = true;
    }

    //Shoots the battery in a parabolic movement
    void launchBattery()
    {
        GameObject battery = GetPooledObject();
        
        Vector3 targetPos;
        if (battery.transform.position.x >= 0)
        {
            targetPos = new Vector3(Random.Range(50, 150), -750, -200);
        }
        else
        {
            targetPos = new Vector3(Random.Range(-150, 50), -750, -200);
        }
        battery.SetActive(true);
        //Choose point slightly to right or left of Battery to launch the battery
        battery.GetComponent<Target>().m_launchLocation = targetPos;

    }
    void launchBonusBattery()
    {
        GameObject battery = GetBonusPooledObject();

        Vector3 targetPos;

        if (battery.transform.position.x >= 0)
        {
            targetPos = new Vector3(Random.Range(50, 150), -750, -200);
        }
        else
        {
            targetPos = new Vector3(Random.Range(-150, 50), -750, -200);
        }
        battery.SetActive(true);
        //Choose point slightly to right or left of Battery to launch the battery
        battery.GetComponent<Target>().m_launchLocation = targetPos;

    }
    void launchElectricBattery()
    {
        GameObject battery = GetElectricPooledObject();

        Vector3 targetPos;

        if (battery.transform.position.x >= 0)
        {
            targetPos = new Vector3(Random.Range(50, 150), -750, -200);
        }
        else
        {
            targetPos = new Vector3(Random.Range(-150, 50), -750, -200);
        }
        battery.SetActive(true);
        //Choose point slightly to right or left of Battery to launch the battery
        battery.GetComponent<Target>().m_launchLocation = targetPos;

    }

    //After the round is over check how many shots it took to shoot the batteries
    //Accuracy is batteries/shots
    float calcAccuracy()
    {
        if(m_numShots == 0)
        {
            return 1;
        }
        return m_level.GetComponent<Level>().m_numBatteries / m_numShots;
    }

    //Gets a battery that has not already been spawned and is not active
    public GameObject GetPooledObject()
    {
        for (int i = 0; i < amountToPool; ++i)
        {
            if (!pooledObjects[i].activeInHierarchy && pooledObjects[i].GetComponent<Target>().m_isSpawned != true)
            {
                return pooledObjects[i];
            }
        }
        return null;
    }
    public GameObject GetBonusPooledObject()
    {
        for (int i = 0; i < amountToPool; ++i)
        {
            if (!bonusPooledObjects[i].activeInHierarchy && bonusPooledObjects[i].GetComponent<Target>().m_isSpawned != true)
            {
                return bonusPooledObjects[i];
            }
        }
        return null;
    }
    public GameObject GetElectricPooledObject()
    {
        for (int i = 0; i < amountToPool; ++i)
        {
            if (!electricPooledObjects[i].activeInHierarchy && electricPooledObjects[i].GetComponent<Target>().m_isSpawned != true)
            {
                return electricPooledObjects[i];
            }
        }
        return null;
    }

    //Resets all the batteries for the next level
    public void resetBatteries()
    {
        for (int i = 0; i < amountToPool; ++i)
        {
            pooledObjects[i].GetComponent<Target>().m_isSpawned = false;
            pooledObjects[i].transform.position = pooledObjects[i].GetComponent<Target>().m_startPos;
            pooledObjects[i].SetActive(false);
            //Change the movement speed
            pooledObjects[i].GetComponent<Target>().m_moveSpeed = (int)(pooledObjects[i].GetComponent<Target>().m_moveSpeed * m_level.GetComponent<Level>().m_batteryMoveSpeedModifier);
        }
        for (int i = 0; i < amountToPool/5; ++i)
        {
            bonusPooledObjects[i].GetComponent<Target>().m_isSpawned = false;
            bonusPooledObjects[i].transform.position = bonusPooledObjects[i].GetComponent<Target>().m_startPos;
            bonusPooledObjects[i].SetActive(false);
            //Change the movement speed
            bonusPooledObjects[i].GetComponent<Target>().m_moveSpeed = (int)(bonusPooledObjects[i].GetComponent<Target>().m_moveSpeed * m_level.GetComponent<Level>().m_batteryMoveSpeedModifier);
        }
        for (int i = 0; i < amountToPool/10; ++i)
        {
            electricPooledObjects[i].GetComponent<Target>().m_isSpawned = false;
            electricPooledObjects[i].transform.position = electricPooledObjects[i].GetComponent<Target>().m_startPos;
            electricPooledObjects[i].SetActive(false);
            //Change the movement speed
            electricPooledObjects[i].GetComponent<Target>().m_moveSpeed = (int)(electricPooledObjects[i].GetComponent<Target>().m_moveSpeed * m_level.GetComponent<Level>().m_batteryMoveSpeedModifier);
        }
    }

    //Gets all of the active batteries on the screen and returns the amount that were blown up
    public int blowUpBatteries()
    {
        int numBatteries = 0;
        for (int i = 0; i < amountToPool; ++i)
        {
            if (pooledObjects[i].activeInHierarchy)
            {
                numBatteries++;
                pooledObjects[i].SetActive(false);
                pooledObjects[i].GetComponent<Target>().m_isSpawned = true;
            }
        }
        return numBatteries;
    }

    //Creates the pool of the 5 different types of batteries
    public void createPool()
    {
        //Make Pool of Objects
        pooledObjects = new List<GameObject>();
        bonusPooledObjects = new List<GameObject>();
        GameObject tmp;
        int increment = 450;
        string[] colorList = { "Red", "Blue", "Purple", "Green", "Yellow" };
        for (int i = 0; i < amountToPool; ++i)
        {
            //Randomize the color
            int color = Random.Range(0, 5);
            //Randomize the Spawnpoint
            Vector3 spawnPoint = new Vector3(Random.Range(0, increment) + increment, -650, -200);
            //Pools Red Batteries
            if(colorList[color] == "Red")
            {
                redBattery.GetComponent<Target>().setColor(colorList[color]);
                redBattery.GetComponent<Target>().m_startPos = spawnPoint;
                redBattery.GetComponent<Renderer>().sharedMaterial.color = Color.red;
                tmp = Instantiate(redBattery, spawnPoint, redBattery.transform.rotation);
                tmp.SetActive(false);
                pooledObjects.Add(tmp);
            }
            //Pools Blue Batteries
            else if (colorList[color] == "Blue")
            {
                blueBattery.GetComponent<Target>().setColor(colorList[color]);
                blueBattery.GetComponent<Target>().m_startPos = spawnPoint;
                blueBattery.GetComponent<Renderer>().sharedMaterial.color = Color.blue;
                tmp = Instantiate(blueBattery, spawnPoint, blueBattery.transform.rotation);
                tmp.SetActive(false);
                pooledObjects.Add(tmp);
            }
            //Pools Green Batteries
            else if (colorList[color] == "Green")
            {
                greenBattery.GetComponent<Target>().setColor(colorList[color]);
                greenBattery.GetComponent<Target>().m_startPos = spawnPoint;
                greenBattery.GetComponent<Renderer>().sharedMaterial.color = Color.green;
                tmp = Instantiate(greenBattery, spawnPoint, greenBattery.transform.rotation);
                tmp.SetActive(false);
                pooledObjects.Add(tmp);
            }
            //Pools Yellow Batteries
            else if (colorList[color] == "Yellow")
            {
                yellowBattery.GetComponent<Target>().setColor(colorList[color]);
                yellowBattery.GetComponent<Target>().m_startPos = spawnPoint;
                yellowBattery.GetComponent<Renderer>().sharedMaterial.color = Color.yellow;
                tmp = Instantiate(yellowBattery, spawnPoint, yellowBattery.transform.rotation);
                tmp.SetActive(false);
                pooledObjects.Add(tmp);
            }
            //Pools Purple Batteries
            else if (colorList[color] == "Purple")
            {
                purpleBattery.GetComponent<Target>().setColor(colorList[color]);
                purpleBattery.GetComponent<Target>().m_startPos = spawnPoint;
                purpleBattery.GetComponent<Renderer>().sharedMaterial.color = Color.magenta;
                tmp = Instantiate(purpleBattery, spawnPoint, purpleBattery.transform.rotation);
                tmp.SetActive(false);
                pooledObjects.Add(tmp);
            }
            increment = -increment;
        }
        for (int i = 0; i < amountToPool/5; i++)
        {
            increment = -increment;
            bonusBattery.GetComponent<Target>().setColor("White");
            Vector3 spawnPoint = new Vector3(Random.Range(0, increment) + increment, -650, -200);
            bonusBattery.GetComponent<Target>().m_startPos = spawnPoint;
            bonusBattery.GetComponent<Renderer>().sharedMaterial.color = Color.white;
            tmp = Instantiate(bonusBattery, spawnPoint, bonusBattery.transform.rotation);
            tmp.SetActive(false);
            bonusPooledObjects.Add(tmp);
        }
        for (int i = 0; i < amountToPool / 10; i++)
        {
            increment = -increment;
            electricBattery.GetComponent<Target>().setColor("Electric");
            electricBattery.GetComponent<Target>().m_isElectricBattery = true;
            Vector3 spawnPoint = new Vector3(Random.Range(0, increment) + increment, -650, -200);
            electricBattery.GetComponent<Target>().m_startPos = spawnPoint;
            electricBattery.GetComponent<Renderer>().sharedMaterial.color = Color.white;
            tmp = Instantiate(electricBattery, spawnPoint, electricBattery.transform.rotation);
            tmp.SetActive(false);
            electricPooledObjects.Add(tmp);
        }
    }



    //Runs the game
    public IEnumerator runGame()
    {
        //Runs until the code is either quit or the game is closed
        while (true)
        {
            //Checks if there are batteries left
            if (m_level.GetComponent<Level>().m_batteriesLeft > 0) //changed this to > 0 because it went into negatives once
            {
                //Updates the ui
                objectiveUpdating.GetComponent<objectiveUpdater>().UpdateObjective(m_level.GetComponent<Level>().m_batteriesLeft, m_level.GetComponent<Level>().m_numBatteries);
                objectiveUpdating.GetComponent<objectiveUpdater>().UpdateScore(m_levelScore);
                //Spawns a battery
                if(pooledObjects.Capacity == 0)
                {
                    resetBatteries();
                }
                for (int i = 0; i < batteriesPerWave; i++)
                {
                    launchBattery();
                }
                //Waits for the battery to spawn
                yield return new WaitForSeconds(m_level.GetComponent<Level>().m_batterySpawnTimer);
                //Spawn the attacks
                StartCoroutine(attackLaunch());
            }
            else if (m_level.GetComponent<Level>().m_batteriesLeft <= 0)
            {
                if (calcAccuracy() == 1)
                {
                    Debug.Log("Bonus Level");
                    //Starting Bonus Level
                    bonusLevelText.SetActive(true);
                    int numBonusBatteries = m_level.GetComponent<Level>().m_level * 5;
                    for (int i = 0; i < numBonusBatteries; i++)
                    {
                        launchBonusBattery();
                    }
                    //Wait for the bonus batteries to despawn
                    yield return new WaitForSeconds(m_level.GetComponent<Level>().m_batterySpawnTimer);
                }
                //Increase the level
                m_level.GetComponent<Level>().increaseLevel();
                batteriesPerWave++;
                //Reset all the batteries
                resetBatteries();
                //turns off bonus level display
                bonusLevelText.SetActive(false);
                //Create new level
                createLevel();
            }

        }


    }

    //Launches the attacks
    public IEnumerator attackLaunch()
    {
        //Spawns the wave
        if (m_level.GetComponent<Level>().m_level > 2 && !m_waveSpawned)
        {
            yield return new WaitForSeconds(m_level.GetComponent<Level>().m_attackTimer);
            sendWave();
        }
        //Spawns the dragon
        if (m_level.GetComponent<Level>().m_level > 3 && !m_dragonSpawned)
        {
            yield return new WaitForSeconds(m_level.GetComponent<Level>().m_attackTimer);
            sendDragon();
        }
        //Spawn the Electric Battery
        if (m_level.GetComponent<Level>().m_level > 5)
        {
            yield return new WaitForSeconds(m_level.GetComponent<Level>().m_attackTimer);
            launchElectricBattery();
        }

    }
    //Creates the level
    public void createLevel()
    {
        string[] colorList = { "Red", "Blue", "Purple", "Green", "Yellow" };
        m_numShots = 0;
        m_level.GetComponent<Level>().m_shots = 0;
        int color = Random.Range(0, 5);
        //Changes level color
        m_level.GetComponent<Level>().m_color = colorList[color];
        //Adds movementspeed to batteries


        //Adds movement speed to attacks
        m_waveSpeed = (m_waveSpeed * m_level.GetComponent<Level>().m_attackMoveSpeedModifier);
        m_dragonSpeed = (m_dragonSpeed * m_level.GetComponent<Level>().m_attackMoveSpeedModifier);

        //Update UI
        float batteriesTotal = m_level.GetComponent<Level>().m_batteriesLeft;
        objectiveUpdating.GetComponent<objectiveUpdater>().UpdateObjective(batteriesTotal, batteriesTotal);
        objectiveUpdating.GetComponent<objectiveUpdater>().UpdateScore(m_levelScore);
        objectiveUpdating.GetComponent<objectiveUpdater>().UpdateObjectiveTitle(colorList[color], batteriesTotal);
    }
    //Runs through the level once(should run untill the num of batteries == 0 )
    // Start is called before the first frame update
    void Start()
    {
        m_levelScore = 0;
        //Create the pool
        createPool();
        createLevel();
        StartCoroutine(runGame());
    }
    // Update is called once per frame
    public void FixedUpdate()
    {
        /*//Checks if the wave is spawned
        if (m_waveSpawned)
        {
            //Move the wave across the screen
            wave.transform.Translate(m_waveSpeed * Time.deltaTime, 0, 0);
            //Checks if wave is Out of bounds if so deletes it
            if (wave.transform.position.x >= 1100)
            {
                Destroy(wave.gameObject);
                m_waveSpawned = false;
            }
        }
        //Checks if the wave is spawned
        if (m_dragonSpawned)
        {
            //Move the wave across the screen
            dragon.transform.Translate(m_dragonSpeed * Time.deltaTime, 0, 0);
            //Checks if wave is Out of bounds if so deletes it
            if (dragon.transform.position.x >= 1100)
            {
                Destroy(dragon.gameObject);
                m_dragonSpawned = false;
            }
        }*/
    }

}
