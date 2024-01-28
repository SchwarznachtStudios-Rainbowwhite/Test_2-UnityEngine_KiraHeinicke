using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterZoneDirty : MonoBehaviour
{
    public WaterZone S_WaterZone;

    // Start is called before the first frame update
    void Start()
    {
        S_WaterZone = GameObject.Find("Water_clean").GetComponent<WaterZone>();

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnMouseDown()
    {
        // Turn water Blue
        S_WaterZone._WaterDirty.enabled = false;
        S_WaterZone._WaterDirtyCollider.enabled = false;

        S_WaterZone._WaterClean.enabled = true;
        S_WaterZone._WaterCleanCollider.enabled = true;

        // reset the water bool and set counter to 0 that determines if apples can be washed
        S_WaterZone._ApplesCleaned = 0;
        S_WaterZone._IsWaterDirty = false;


    }

}
