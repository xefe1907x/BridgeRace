using System;
using Unity.VisualScripting;
using UnityEngine;

public class BrickSlotController : MonoBehaviour
{
    public GameObject greenBrick;
    public GameObject blueBrick;
    public GameObject redBrick;
    public GameObject yellowBrick;

    bool isEmpty = true;

    int brickNumber; // 1 = Green,  2 = Blue,  3 = Red,  4 = Yellow

    void Start()
    {
        RandomNumberCreator();
    }

    void Update()
    {
        BrickInstantiator();
    }

    void RandomNumberCreator()
    {
        brickNumber = UnityEngine.Random.Range(1, 5);
    }

    void BrickInstantiator()
    {
        if (isEmpty)
        {
            switch (brickNumber)
            {
                case 1:
                    Instantiate(greenBrick, transform);
                    isEmpty = false;
                    break;
                
                case 2:
                    Instantiate(blueBrick, transform);
                    isEmpty = false;
                    break;
                
                case 3:
                    Instantiate(redBrick, transform);
                    isEmpty = false;
                    break;
                
                case 4:
                    Instantiate(yellowBrick, transform);
                    isEmpty = false;
                    break;
            }
        }
    }
}
