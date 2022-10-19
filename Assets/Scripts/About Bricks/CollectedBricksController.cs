using System;
using Unity.VisualScripting;
using UnityEngine;

public class CollectedBricksController : MonoBehaviour
{
    // TODO: Player bricks diye gameobject oluştur sonra player üzerindeki bricks positionsu ona ata. brick aldıkca getchild active olsun.
    
    public GameObject playerBrickHolder;

    int _collectedBricks = 0;

    void Start()
    {
        PlayerControl.collectBricks += IncreaseCollectedBricks;
    }

    void Update()
    {
        PlayerBricksActivator();
        Debug.Log(_collectedBricks);
    }

    void IncreaseCollectedBricks()
    {
        _collectedBricks += 1;
    }

    void PlayerBricksActivator()
    {
        
    }

    void OnDisable()
    {
        PlayerControl.collectBricks -= IncreaseCollectedBricks;
    }
}
