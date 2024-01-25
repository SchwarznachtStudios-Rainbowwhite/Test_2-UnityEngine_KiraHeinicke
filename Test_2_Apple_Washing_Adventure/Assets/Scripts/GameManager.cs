using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
// VARIABLES

    // Apple Stuff
    public GameObject[] Apple = new GameObject[5];
    [HideInInspector]public int AppleCount = 0;

    public int[] AppleDirt = new int[5] { 500, 500, 500, 500, 500};

    // Lists
    public List<GameObject> AppleList_Spawned = new List<GameObject>();
    public List<GameObject> AppleList_Basket = new List<GameObject>();

    public List<int> AppleList_DirtAmount = new List<int>();


// START
    void Start()
    {
        FindingCall();


    }

// UPDATE
    void Update()
    {
        SpawnApples();


  
    }

// FUNCTIONS

    // Randomize each Apples color 
    public void RandomColor()
    {
        for (int i = 0; i < Apple.Length; i++)
        {
            Color newColor = new Color(Random.value, Random.value, Random.value, 1.0f);

            Apple[i].GetComponent<Renderer>().material.color = newColor;

        }

    }

    // Finding
    public void FindingCall()
    {
        Apple = GameObject.FindGameObjectsWithTag("Apple");
        AppleList_Spawned = Apple.ToList();


    }

    public void SpawnApples()
    {
        // Instantiates Apple when under 10 apples exist + random color every 30 seconds to 1 minute or so
        if (AppleCount < 5)
        {
            // Instantiate
            // loop: replace object in array if health = 0; applecount+1

            // Add to Spawned List

        }

    }


}
