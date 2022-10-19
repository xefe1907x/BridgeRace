using System;
using Unity.VisualScripting;
using UnityEngine;

public class CollectedBricksController : MonoBehaviour
{    
    public GameObject playerBrickHolder;

    int _collectedBricks = 0;

    void Start()
    {
        PlayerControl.collectBricks += IncreaseCollectedBricks;
    }

    void Update()
    {
        PlayerBricksActivator();
    }

    void IncreaseCollectedBricks()
    {
        _collectedBricks += 1;
    }

    void PlayerBricksActivator()
    {
        if (_collectedBricks != 0)
        {
            for (int i = 0; i < _collectedBricks; i++)
            {
                if (playerBrickHolder.gameObject.transform.GetChild(i).gameObject.activeInHierarchy == false)
                {
                    playerBrickHolder.gameObject.transform.GetChild(i).gameObject.SetActive(true);
                }
            }
        }
    }

    void OnDisable()
    {
        PlayerControl.collectBricks -= IncreaseCollectedBricks;
    }
}
