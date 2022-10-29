using System;
using UnityEngine;

public class YellowStairController : MonoBehaviour
{
    float moveTreshHold = 0.63f;

    public static Action yellowBricksAreZero;

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<Player>())
        {
            if (other.gameObject.GetComponent<YellowPlayer>())
            {
                if (CollectedBricksController.Instance.yellowPlayerBricks > 0)
                {
                    gameObject.transform.position = new Vector3(transform.position.x, transform.position.y,
                        transform.position.z + moveTreshHold);
                    
                    CollectedBricksController.Instance.yellowPlayerBricks -= 1;
                    
                    if (CollectedBricksController.Instance.yellowPlayerBricks == 0)
                    {
                        yellowBricksAreZero.Invoke();
                    }
                }
            }
            
            else if (other.gameObject.GetComponent<RedPlayer>())
            {
                gameObject.GetComponent<BoxCollider>().isTrigger = true;
            }
            
            else if (other.gameObject.GetComponent<BluePlayer>())
            {
                gameObject.GetComponent<BoxCollider>().isTrigger = true;
            }
            
            else if (other.gameObject.GetComponent<GreenPlayer>())
            {
                gameObject.GetComponent<BoxCollider>().isTrigger = true;
            }
        }
    }
}
