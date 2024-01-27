using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeZone : MonoBehaviour
{
// VARIABLES

    public GameManager S_GameManager;


// START


    public void Start()
    {
        S_GameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

// FUNCTIONS


    public void OnTriggerExit(Collider other)
    {
        for (int i = 0; i < S_GameManager.Apple.Length; i++)
        {
            if (other.gameObject == S_GameManager.Apple[i])
            {
                // turn on gravity, turn off kinematic


                Rigidbody RB = other.gameObject.GetComponent<Rigidbody>();
                RB.isKinematic = false;
                RB.detectCollisions = true;
                RB.useGravity = true;

            }
            
        }
    }



}
