using System;
using UnityEngine;

public class RedStairController : MonoBehaviour
{
    float moveTreshHold = 0.63f;

    public static Action redBricksAreZero;

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<Player>())
        {
            if (other.gameObject.GetComponent<RedPlayer>())
            {
                if (CollectedBricksController.Instance.redPlayerBricks > 0)
                {
                    gameObject.transform.position = new Vector3(transform.position.x, transform.position.y,
                        transform.position.z + moveTreshHold);
                    
                    CollectedBricksController.Instance.redPlayerBricks -= 1;

                    if (CollectedBricksController.Instance.redPlayerBricks == 0)
                    {
                        redBricksAreZero.Invoke();
                    }
                }
            }
        }
    }
}
