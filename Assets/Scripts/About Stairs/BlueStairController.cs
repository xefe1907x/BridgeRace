using System;
using UnityEngine;

public class BlueStairController : MonoBehaviour
{
    float moveTreshHold = 0.63f;

    Vector3 firstPosition;

    void Start()
    {
        firstPosition = gameObject.transform.position;
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<Player>())
        {
            if (collision.gameObject.GetComponent<BluePlayer>())
            {
                if (CollectedBricksController.Instance.bluePlayerBricks > 0)
                {
                    gameObject.transform.position = new Vector3(transform.position.x, transform.position.y,
                        transform.position.z + moveTreshHold);
                    
                    CollectedBricksController.Instance.bluePlayerBricks -= 1;
                }
            }
            
            else if (collision.gameObject.GetComponent<RedPlayer>())
            {
                gameObject.GetComponent<BoxCollider>().isTrigger = true;
            }
            
            else if (collision.gameObject.GetComponent<GreenPlayer>())
            {
                gameObject.GetComponent<BoxCollider>().isTrigger = true;
            }
            
            else if (collision.gameObject.GetComponent<YellowPlayer>())
            {
                gameObject.GetComponent<BoxCollider>().isTrigger = true;
            }
        }
    }

    void OnTriggerExit(Collider other)
    {
        gameObject.GetComponent<BoxCollider>().isTrigger = false;
        transform.position = firstPosition;
    }
}
