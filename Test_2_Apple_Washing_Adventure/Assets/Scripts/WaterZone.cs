using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterZone : MonoBehaviour
{
// VARIABLES

    public GameManager S_GameManager;

    // water objects
    public MeshRenderer _WaterClean;
    public MeshRenderer _WaterDirty;

    public bool _IsWaterDirty = false;

    private int _ApplesCleaned = 0;




// START
    void Start()
    {
        S_GameManager = GameObject.Find("GameManager").GetComponent<GameManager>();

        FindingCalls();

    }

// UPDATE
    private void Update()
    {
        WaterQuality();
    }

// FUNCTIONS
    public void OnTriggerStay(Collider other)
    {
        // if water == clean do:
        if (_IsWaterDirty == false)
        {
            for (int i = 0; i < S_GameManager.Apple.Length; i++)
            {
                if (other.gameObject == S_GameManager.Apple[i])
                {
                    S_GameManager.AppleDirt[i] = S_GameManager.AppleDirt[i] - 1;

                    if (S_GameManager.AppleDirt[i] == 0)
                    {
                        // Change Color of now clean apple to red
                        _ApplesCleaned++;
                        Renderer AppleRenderer = S_GameManager.Apple[i].GetComponent<Renderer>(); 
                        AppleRenderer.material.color = Color.red;
                        // Destroy(S_GameManager.Apple[i]);
                        // Play clean sound
                    }
                }
            }
        }
    }

    public void WaterQuality()
    {
        // Counter: after 3 apples cleaned -> water dirty
        // when water dirty, change its material from water clean to water dirty
        // when clicked on water, it turns back to water clean material

        if (_ApplesCleaned == 3)
        {
            // Turn Water dirty
            _WaterDirty.enabled = true;
            _WaterClean.enabled = false;

            _IsWaterDirty = true;

        }
    }

    public void OnMouseDown()
    {
        // Turn water Blue
        _WaterDirty.enabled = false;
        _WaterClean.enabled = true;

        _ApplesCleaned = 0;
        _IsWaterDirty = false;


    }

    public void FindingCalls()
    {
        _WaterClean = GameObject.Find("Water_clean").GetComponent<MeshRenderer>();
        _WaterDirty = GameObject.Find("Water_dirty").GetComponent<MeshRenderer>();
        _WaterDirty.enabled = false;


    }

}
