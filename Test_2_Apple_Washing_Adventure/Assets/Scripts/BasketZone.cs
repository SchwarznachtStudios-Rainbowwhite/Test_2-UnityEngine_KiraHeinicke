using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasketZone : MonoBehaviour
{
    // VARIABLES

    public GameManager S_GameManager;

// START
    void Start()
    {
        S_GameManager = GameObject.Find("GameManager").GetComponent<GameManager>();

    }

    // UPDATE
    void Update()
    {
        
    }

// FUNCTIONS


    public void OnTriggerEnter(Collider other)
    {
        for (int i = 0; i < S_GameManager.Apple.Length; i++)
        {
            if (other.gameObject == S_GameManager.Apple[i])
            {
                if (S_GameManager.AppleDirt[i] < 0)
                {
                    gameObject.GetComponent<DragAndDrop>().enabled = false;

                    S_GameManager.AppleCount--;


                    //Destroy(S_GameManager.Apple[i]);
                }
            }

        }

    }


}
