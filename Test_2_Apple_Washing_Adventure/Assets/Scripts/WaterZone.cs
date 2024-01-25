using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterZone : MonoBehaviour
{
// VARIABLES

    public GameManager S_GameManager;


// START
    void Start()
    {
        S_GameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }


// FUNCTIONS
    public void OnTriggerStay(Collider other)
    {
        // if water = clean do:

        for (int i = 0; i < S_GameManager.Apple.Length; i++)
        {
            if (other.gameObject == S_GameManager.Apple[i])
            {
                S_GameManager.AppleDirt[i] = S_GameManager.AppleDirt[i] -1 ;

                if (S_GameManager.AppleDirt[i] < 0)
                {
                    // Change Color of now clean apple to red
                    //cubeRenderer.material.SetColor("_Color", Color.red);
                    //Destroy(S_GameManager.Apple[i]);
                }
            }

        }

    }

}
