using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyKill : MonoBehaviour
{
    public LivesManager livesManagerScript;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

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
