using System;
using UnityEngine;

public class RedStairController : MonoBehaviour
{
    float moveTreshHold = 0.63f;
    
    Vector3 firstPosition;

    public static Action redBricksAreZero;

    void Start()
    {
        firstPosition = gameObject.transform.position;
    }

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
            
            else if (other.gameObject.GetComponent<BluePlayer>())
            {
                gameObject.GetComponent<BoxCollider>().isTrigger = true;
            }
            
            else if (other.gameObject.GetComponent<YellowPlayer>())
            {
                gameObject.GetComponent<BoxCollider>().isTrigger = true;
            }
            
            else if (other.gameObject.GetComponent<GreenPlayer>())
            {
                gameObject.GetComponent<BoxCollider>().isTrigger = true;
            }
        }
    }

    void OnTriggerExit(Collider other)
    {
        // gameObject.GetComponent<BoxCollider>().isTrigger = false;
        // transform.position = firstPosition;
    }
}
