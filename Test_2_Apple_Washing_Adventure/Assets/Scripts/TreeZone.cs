using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeZone : MonoBehaviour
{
// VARIABLES

    public GameManager S_GameManager;

    public GameObject[] BrokenApple = new GameObject[5];


    // START


    public void Start()
    {
        S_GameManager = GameObject.Find("GameManager").GetComponent<GameManager>();

    }

// FUNCTIONS

    // when apples are dragged out of the trees trigger, allow them to fall, otherwise they stay in their spawn point
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


    /*public void OnTriggerStay(Collider other)
    {
        // look through all objects of the apple array
        for (int i = 0; i < S_GameManager.Apple.Length; i++)
        {
            // checks if the object in trigger is in apple array
            if (other.gameObject == S_GameManager.Apple[i])
            {
                // counts up "Health" of apple until overripe reached
                S_GameManager.AppleRipeLevel[i] = S_GameManager.AppleRipeLevel[i] + 1;

                // once "HP" reaches 700, apple overripe and falls
                if (S_GameManager.AppleRipeLevel[i] == 700)
                {
                    // change tag
                    other.gameObject.tag = "BrokenApple";


                    // find all objects with tag, add to array
                    BrokenApple = GameObject.FindGameObjectsWithTag("BrokenApple");

                    // enable the Fracture script on the object
                    for (int b = 0; b < BrokenApple.Length; b++)
                    {
                        BrokenApple[b].GetComponent<Fracture>().enabled = true;
                    }

                    // allow Apples to fall to the ground
                    Rigidbody RB = other.gameObject.GetComponent<Rigidbody>();
                    RB.isKinematic = false;
                    RB.detectCollisions = true;
                    RB.useGravity = true;

                    // broken apples are removed from applecount -> allow new to spawn
                    S_GameManager.AppleCount--;

                    // reset the ripe counter, when their counter is over 700 (broken apples) back to 0
                    for (int j = 0; j < S_GameManager.Apple.Length; j++)
                    {
                        if (S_GameManager.AppleRipeLevel[j] > 700)
                        {
                            S_GameManager.AppleRipeLevel[j] = 0;
                        }
                    }

                    // call the function that destroys the broken apples
                    Invoke("DestoryBrokenApples", 5);

                }
            }
        }
    }

    public void DestroyBrokenApples()
    {
        // destroy objects with broken apple tag
        for (int l = 0; l < BrokenApple.Length; l++)
        {
            Destroy(BrokenApple[l]);
        }

    }*/

}
