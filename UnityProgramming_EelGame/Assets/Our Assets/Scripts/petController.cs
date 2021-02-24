using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class petController : MonoBehaviour
{
    public GameObject player;

    public float jumpHeight;
    public float duckAmount;

    public bool atStart;
    public Vector3 startPos;
    public Vector3 jumpPos;
    public Vector3 duckPos;

    public GameObject livesManage;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        startPos = player.transform.position;
        jumpPos = new Vector3(player.transform.position.x, player.transform.position.y + jumpHeight, player.transform.position.z);
        duckPos = new Vector3(player.transform.position.x, player.transform.position.y - duckAmount, player.transform.position.z);
    }

    // Update is called once per frame
    void Update()
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
    void OnCollissionEnter(Collision other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            livesManage.GetComponent<LivesManager>().hit = true;
        }
    }

}
