using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrickSlotController : MonoBehaviour
{
    public GameObject greenBrick;
    public GameObject blueBrick;
    public GameObject redBrick;
    public GameObject yellowBrick;

    bool isBrickInstantiated;

    void Update()
    {
        
    }

    void BrickInstantiator()
    {
        if (!isBrickInstantiated)
        {
            // switch case kullan 1-4 arası bi tuğla instantiate et
        }
    }
}
