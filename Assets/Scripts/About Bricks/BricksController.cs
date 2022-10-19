using UnityEngine;

public class BricksController : MonoBehaviour
{
    private int rebornTimer = 7;
    private float _counter;
    void Update()
    {
        BricksActivatorWithDelay();
    }

    void BricksActivatorWithDelay()
    {
        if (gameObject.transform.childCount > 0)
        {
            if (!gameObject.transform.GetChild(0).gameObject.activeInHierarchy)
            {
                _counter += Time.deltaTime;

                if (_counter >= rebornTimer)
                {
                    gameObject.transform.GetChild(0).gameObject.SetActive(true);
                    _counter = 0;
                }
            }
        }
    }
}
