using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyKill : MonoBehaviour
{
    public GameObject livesManagerScript;

    // Start is called before the first frame update
    void Start()
    {
        livesManagerScript = GameObject.FindGameObjectWithTag("livesManager");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("left")) //jumps up
        {
            livesManagerScript.GetComponent<LivesManager>().hit = true;
        }
    }

    private void OnCollisionEnter(Collision other)
    //When Wave or Dragon hits character, lives script takes -1 life
    {
        if (LayerMask.LayerToName(other.gameObject.layer) == "Player")
        {
            livesManagerScript.GetComponent<LivesManager>().hit = true;
        }
    }
}
