using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    // VARIABLES

    // Apple Spawn
    public GameObject _ApplePrefab;

    // Apple Arrays
    public GameObject[] Apple = new GameObject[5];
    public int AppleCount = 0;

    public int[] AppleDirt = new int[5] { 400, 400, 400, 400, 400 };

    // Lists
    public List<GameObject> AppleList_Spawned = new List<GameObject>();
    public List<GameObject> AppleList_Basket = new List<GameObject>();

    //public List<int> AppleList_DirtAmount = new List<int>();

    // RestartScreen / FinishGame
    private GameObject _RestartScreen;

    [HideInInspector] public int _AppleCollectedAmount;

    // CounterUI

    [HideInInspector] public TMP_Text Txt_AppleCollectCounter;

    // Destruction Variables
    public int[] AppleRipeLevel= new int[5] { 0, 0, 0, 0, 0 };





    // START
    void Start()
    {
        FindingCall();


    }

// UPDATE
    void Update()
    {
        SpawnAppleSystem();


  
    }

// FUNCTIONS

    // Randomize each Apples color 
    public void RandomColor()
    {
        // goes through the apple array
        for (int i = 0; i < Apple.Length; i++)
        {
            // randomizes a color
            Color newColor = new Color(Random.value, Random.value, Random.value, 1.0f);

            // assigns randomized color to the apple objects
            Apple[i].GetComponent<Renderer>().material.color = newColor;

        }

    }

    
    public void SpawnAppleSystem()
    {
        // Instantiates Apple when under 5 apples exist + random color; every 30 seconds to 1 minute or so
        if (AppleCount < 5)
        {
            // spawnapple every 10 seconds
            StartCoroutine(SpawnApple());
        }

    }

    public IEnumerator SpawnApple()
    {
        // Spawns New Apple in the specified Area
        GameObject NewApple = Instantiate(_ApplePrefab, new Vector3(Random.Range(1, 4), 3, Random.Range(2, -2)), Quaternion.identity);
        AppleCount++;

        // Adds newly spawned Apple to list
        AppleList_Spawned.Add(NewApple);

        // adds the 5 current apple tag apples to the apple array for the rest of the functions to work
        for (int i = 0; i < 5; i++)
        {
            Apple = GameObject.FindGameObjectsWithTag("Apple");

        }

        // randomizes uncollected apples color
        RandomColor();

        yield return new WaitForSeconds(5);
    }



    public void GameEnd()
    {
        // when 10 apples collected, finish game
        if (_AppleCollectedAmount == 10)
        {
            _RestartScreen.SetActive(true);
        }

    }


    public void Restart()
    {
        // Reload Scene
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);

    }

    // Finding Objects ect.
    public void FindingCall()
    {
        Apple = GameObject.FindGameObjectsWithTag("Apple");
        AppleList_Spawned = Apple.ToList();

        // FinishScreenStuff
        _RestartScreen = GameObject.Find("RestartScreen");
        _RestartScreen.SetActive(false);

        Txt_AppleCollectCounter = GameObject.Find("AppleCollectCounter").GetComponent<TMP_Text>();

    }

}
