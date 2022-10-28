using UnityEngine;

[DefaultExecutionOrder(100)]
public class BricksController : MonoBehaviour
{
    Brick _brick;

    void Start()
    {
        _brick = GetComponentInChildren<Brick>(true);
        InvokeRepeating(nameof(BricksActivatorWithDelay),7,7);
    }
    
    void BricksActivatorWithDelay()
    {
        if (_brick.isTaken)
        {
            _brick.gameObject.SetActive(true);
            _brick.isTaken = false;
        }
    }
}
