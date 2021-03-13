using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*Julia Sousa & Luke Driscoll
 * 2345424 // 2344496
 * jsousa@chapman.edu // ldriscoll@chapman.edu
 * CPSC245-01
 * P1 - Target Roast Milestone I
 * A script that moves the player up and down based on input (W,S,up, and down) and checks to see if any attack is hitting the player
 * */

public class petController : MonoBehaviour
{
    //holds the player object 
    public GameObject player;

    //the amount to move the player up when jumping
    public float jumpHeight;

    //the amount to move down when ducking
    public float duckAmount;

    //Location of Player's start position
    public Vector3 startPos;

    //Location of Player's jumping position
    public Vector3 jumpPos;

    //Location of Player's ducking position
    public Vector3 duckPos;

    //LivesManager object to access life count for when the player gets hit by a dragon or wave
    public GameObject livesManage;

    //checks if game is paused
    public bool isPaused;

    // Start is called before the first frame update, sets starting position, jumpheight and duckheight
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        startPos = player.transform.position;
        jumpPos = new Vector3(player.transform.position.x, player.transform.position.y + jumpHeight, player.transform.position.z);
        duckPos = new Vector3(player.transform.position.x, player.transform.position.y - duckAmount, player.transform.position.z);
    }

    // Update is called once per frame, checks to see if any keys are being pressed/let go by the player to move the robot character accordingly
    void Update()
    {
        if (!isPaused) //makes sure the game isn't paused so the player doesn't move when game is paused
        {
            if (Input.GetKeyDown("up") || Input.GetKeyDown(KeyCode.W) && !Input.GetKey("down") && !Input.GetKey(KeyCode.S)) //jumps up
            {
                player.transform.position = jumpPos;
            }
            else if (Input.GetKeyUp("up") || Input.GetKeyUp(KeyCode.W) && !Input.GetKey("down") && !Input.GetKey(KeyCode.S)) //moves player back to start position
            {
                player.transform.position = startPos;
            }
            else if (Input.GetKeyDown("down") || Input.GetKeyDown(KeyCode.S) && !Input.GetKey("up") && !Input.GetKey(KeyCode.W)) //ducks down
            {
                player.transform.position = duckPos;
            }
            else if (Input.GetKeyUp("down") || Input.GetKeyUp(KeyCode.S) && !Input.GetKey("up") && !Input.GetKey(KeyCode.W)) //moves player back to start position
            {
                player.transform.position = startPos;
            }
        }
    }

    //Checks to see if Dragon or Wave have entered the collision box and access lives manager to lose a life and/or die
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            livesManage.GetComponent<LivesManager>().hit = true;
        }
    }

}
