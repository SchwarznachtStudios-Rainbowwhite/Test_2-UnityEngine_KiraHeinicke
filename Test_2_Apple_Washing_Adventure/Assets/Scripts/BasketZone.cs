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
        // counts through apple array
        for (int i = 0; i < S_GameManager.Apple.Length; i++)
        {
            // checks if object in trigger is apple
            if (other.gameObject == S_GameManager.Apple[i])
            {
                // if dirt amount is lower than 0
                if (S_GameManager.AppleDirt[i] < 0)
                {
                    // destroy drag n drop script on that apple (unmovable)
                    Destroy(other.gameObject.GetComponent<DragAndDrop>());
                    // change its tag
                    other.gameObject.tag = "BasketApple";

                    // add object to list of collected apples
                    S_GameManager.AppleList_Basket.Add(other.gameObject);
                    S_GameManager.AppleList_Spawned.Remove(other.gameObject);

                    // lower count of apples in scene, count the collected ones +1
                    S_GameManager.AppleCount--;
                    S_GameManager._AppleCollectedAmount++;

                    // write the collected apples into UI COunter
                    S_GameManager.Txt_AppleCollectCounter.text = S_GameManager._AppleCollectedAmount.ToString();


                }
            }

        }

    }


}
