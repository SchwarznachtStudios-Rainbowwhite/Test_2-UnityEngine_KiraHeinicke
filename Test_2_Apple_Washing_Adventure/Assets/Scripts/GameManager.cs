using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    // VARIABLES

    // Apple Spawn
    public GameObject _ApplePrefab;

    // Apple Arrays
    public GameObject[] Apple = new GameObject[5];
    public int AppleCount = 0;

    public int[] AppleDirt = new int[5] { 500, 500, 500, 500, 500};

    // Lists
    public List<GameObject> AppleList_Spawned = new List<GameObject>();
    public List<GameObject> AppleList_Basket = new List<GameObject>();

    public List<int> AppleList_DirtAmount = new List<int>();

    // RestartScreen / FinishGame
    private GameObject _RestartScreen;

    [HideInInspector] public int _AppleCollectedAmount;

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
        for (int i = 0; i < Apple.Length; i++)
        {
            Color newColor = new Color(Random.value, Random.value, Random.value, 1.0f);

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

            // loop: replace object in array if health = 0; applecount+1
            



            // Add to Spawned List

        }

    }

    public IEnumerator SpawnApple()
    {
        Instantiate(_ApplePrefab, new Vector3(Random.Range(1, 4), 3, Random.Range(2, -2)), Quaternion.identity);
        AppleCount++;

        for (int i = 0; i < 5; i++)
        {
            Apple = GameObject.FindGameObjectsWithTag("Apple");

        }

        RandomColor();

        yield return new WaitForSeconds(10);
    }



    public void GameEnd()
    {
        // when 10 apples washed, finish game
        if (_AppleCollectedAmount == 10)
        {
            _RestartScreen.SetActive(true);
        }

    }


    public void Restart()
    {

        SceneManager.LoadScene(SceneManager.GetActiveScene().name);

    }

    // Finding
    public void FindingCall()
    {
        Apple = GameObject.FindGameObjectsWithTag("Apple");
        AppleList_Spawned = Apple.ToList();

        // FinishScreenStuff
        _RestartScreen = GameObject.Find("RestartScreen");
        _RestartScreen.SetActive(false);


    }

}
