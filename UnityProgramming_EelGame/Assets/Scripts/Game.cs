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
    public int m_waveSpeed;

    //GameObject for Dragon
    public GameObject m_dragon;

    //The Speed of the dragon
    public int m_dragonSpeed;

    private bool m_waveSpawned = false;

    private GameObject wave;

    private bool m_dragonSpawned = false;

    private GameObject dragon;

    public GameObject m_level;

    public GameObject m_livesManager;


    //Pooling
    public List<GameObject> pooledObjects;

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


    public int amountToPool;


    //Sends the wave attack across the screen
    void sendWave()
    {
        if(m_currLevel>=2)
        {
            //StartCoroutine(attackWait());
            //Instantiates a wave object
            Vector3 pos = new Vector3(-1100, -400, -100);
            wave = Instantiate(m_wave, pos, m_wave.transform.rotation);
            //Sends it across the screen
            m_waveSpawned = true;
        }

    }

    //Sends the Dragon attack across the screen
    void sendDragon()
    {
        if (m_currLevel >= 3)
        {
            //StartCoroutine(attackWait()); 
            //Instantiates a dragon object
            Vector3 pos = new Vector3(-1100, -200, -100);
            dragon = Instantiate(m_dragon, pos, m_wave.transform.rotation);
            //Sends it across the screen
            m_dragonSpawned = true;

        }
    }
    //Shoots the battery in a parabolic movement
    void launchBattery()
    {
        GameObject battery = GetPooledObject();

        //Launches battery
        Vector3 targetPos;

        if (battery.transform.position.x >= 0)
        {
            targetPos = new Vector3(Random.Range(50,150), -650, -200);
        }
        else
        {
            targetPos = new Vector3(Random.Range(-150, 50), -650, -200);
        }
        battery.SetActive(true);
        //Choose point slightly to right or left of Battery
        battery.GetComponent<Target>().m_launchLocation = targetPos;

    }

    //After the round is over check how many shots it took to shoot the batteries
    //Accuracy is batteries/shots
    float calcAccuracy()
    {
        return (float)m_numBatteries/m_numShots;
    }

    public GameObject GetPooledObject()
    {
        for(int i=0; i < amountToPool*5; ++i)
        {
            if(!pooledObjects[i].activeInHierarchy && pooledObjects[i].GetComponent<Target>().m_isSpawned!=true)
            {
                return pooledObjects[i];
            }
        }
        return null;
    }

    public void resetBatteries()
    {
        for (int i = 0; i < amountToPool * 5; ++i)
        {
            pooledObjects[i].GetComponent<Target>().m_isSpawned = false;
            pooledObjects[i].transform.position = pooledObjects[i].GetComponent<Target>().m_startPos;
            pooledObjects[i].SetActive(false);
        }
    }

    public void createPool()
    {
        //Make Pool of Objects
        pooledObjects = new List<GameObject>();
        GameObject tmp;
        int increment = 450;
        string[] colorList = { "Red", "Blue", "Purple", "Green", "Yellow" };
        for (int i = 0; i < amountToPool*5; ++i)
        {
            int color = Random.Range(0, 5);
            Vector3 spawnPoint = new Vector3(Random.Range(0, increment) + increment, -650, -200);
            //Pools Red Batteries
            if(colorList[color] == "Red")
            {
                redBattery.GetComponent<Target>().setColor(colorList[color]);
                redBattery.GetComponent<Renderer>().sharedMaterial.color = Color.red;
                tmp = Instantiate(redBattery, spawnPoint, redBattery.transform.rotation);
                tmp.SetActive(false);
                pooledObjects.Add(tmp);
            }
            else if (colorList[color] == "Blue")
            {
                blueBattery.GetComponent<Target>().setColor(colorList[color]);
                blueBattery.GetComponent<Renderer>().sharedMaterial.color = Color.blue;
                tmp = Instantiate(blueBattery, spawnPoint, blueBattery.transform.rotation);
                tmp.SetActive(false);
                pooledObjects.Add(tmp);
            }
            else if (colorList[color] == "Green")
            {
                greenBattery.GetComponent<Target>().setColor(colorList[color]);
                greenBattery.GetComponent<Renderer>().sharedMaterial.color = Color.green;
                tmp = Instantiate(greenBattery, spawnPoint, greenBattery.transform.rotation);
                tmp.SetActive(false);
                pooledObjects.Add(tmp);
            }
            else if (colorList[color] == "Yellow")
            {
                yellowBattery.GetComponent<Target>().setColor(colorList[color]);
                yellowBattery.GetComponent<Renderer>().sharedMaterial.color = Color.yellow;
                tmp = Instantiate(yellowBattery, spawnPoint, yellowBattery.transform.rotation);
                tmp.SetActive(false);
                pooledObjects.Add(tmp);
            }
            else if (colorList[color] == "Purple")
            {
                purpleBattery.GetComponent<Target>().setColor(colorList[color]);
                purpleBattery.GetComponent<Renderer>().sharedMaterial.color = Color.magenta;
                tmp = Instantiate(purpleBattery, spawnPoint, purpleBattery.transform.rotation);
                tmp.SetActive(false);
                pooledObjects.Add(tmp);
            }
            increment = -increment;
        }
    }
    public IEnumerator attackWait()
    {
        yield return new WaitForSeconds(m_level.GetComponent<Level>().m_attackTimer);
    }

    public IEnumerator batteryLaunch()
    {
        while (true)
        {
            if(m_level.GetComponent<Level>().m_batteriesLeft != 0)
            {
                Debug.Log(m_level.GetComponent<Level>().m_batteriesLeft + " batteries left");
                //Spawns the amount of batteries
                launchBattery();
                yield return new WaitForSeconds(m_level.GetComponent<Level>().m_batterySpawnTimer);
            }
            else if (m_level.GetComponent<Level>().m_batteriesLeft <= 0)
            {
                //Increase the level
                m_level.GetComponent<Level>().increaseLevel();
                //Reset all the batteries
                resetBatteries();
                //Create new level
                createLevel();
            }
        }


    }
    void createLevel()
    {
        string[] colorList = { "Red", "Blue", "Purple", "Green", "Yellow" };
        m_levelScore = 0;
        m_numShots = 0;
        m_level.GetComponent<Level>().m_shots = 0;
        int color = Random.Range(0, 5);
        //Changes level color
        m_level.GetComponent<Level>().m_color = colorList[color];
        Debug.Log("Color: " + colorList[color]);
    }
    //Runs through the level once(should run untill the num of batteries == 0 )
    // Start is called before the first frame update
    void Start()
    {
        m_levelScore = 0;
        //Create the pool
        createPool();
        createLevel();
        StartCoroutine(batteryLaunch());
    }
    // Update is called once per frame
    void FixedUpdate()
    {

        if (m_waveSpawned)
        {
            //Move the wave across the screen
            wave.transform.Translate(m_waveSpeed * Time.deltaTime, 0, 0);
            //Checks if wave is Out of bounds if so deletes it
            if (wave.transform.position.x >= 1100)
            {
                Destroy(wave);
                m_waveSpawned = false;
            }
        }
        if (m_dragonSpawned)
        {
            //Move the wave across the screen
            dragon.transform.Translate(m_dragonSpeed * Time.deltaTime, 0, 0);
            //Checks if wave is Out of bounds if so deletes it
            if (dragon.transform.position.x >= 1100)
            {
                Destroy(dragon);
                m_dragonSpawned = false;
            }
        }
        

    }
}
