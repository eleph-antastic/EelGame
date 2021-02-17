using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class petController : MonoBehaviour
{
    public GameObject player;

    public float jumpHeight;
    public float duckAmount;

    public bool atStart;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        atStart = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("up") || Input.GetKeyDown(KeyCode.W) && atStart) //jumps up
        {
            atStart = false;
            player.transform.position = new Vector3(player.transform.position.x, player.transform.position.y + jumpHeight, player.transform.position.z);
        }
        else if (Input.GetKeyUp("up") || Input.GetKeyUp(KeyCode.W) && !atStart) //moves player back to start position
        {
            player.transform.position = new Vector3(player.transform.position.x, player.transform.position.y - jumpHeight, player.transform.position.z);
            atStart = true;
        }
        else if (Input.GetKeyDown("down") || Input.GetKeyDown(KeyCode.S) && atStart) //ducks down
        {
            atStart = false;
            player.transform.position = new Vector3(player.transform.position.x, player.transform.position.y - duckAmount, player.transform.position.z);
        }
        else if (Input.GetKeyUp("down") || Input.GetKeyUp(KeyCode.S) && !atStart) //moves player back to start position
        {
            player.transform.position = new Vector3(player.transform.position.x, player.transform.position.y + duckAmount, player.transform.position.z);
            atStart = true;
        }
    }
}
