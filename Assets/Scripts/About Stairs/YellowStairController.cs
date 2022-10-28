using System;
using UnityEngine;

public class YellowStairController : MonoBehaviour
{
    float moveTreshHold = 0.63f;
    
    Vector3 firstPosition;
    
    public static Action yellowBricksAreZero;

    void Start()
    {
        firstPosition = gameObject.transform.position;
    }
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<Player>())
        {
            if (collision.gameObject.GetComponent<YellowPlayer>())
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
            
            else if (collision.gameObject.GetComponent<RedPlayer>())
            {
                gameObject.GetComponent<BoxCollider>().isTrigger = true;
            }
            
            else if (collision.gameObject.GetComponent<BluePlayer>())
            {
                gameObject.GetComponent<BoxCollider>().isTrigger = true;
            }
            
            else if (collision.gameObject.GetComponent<GreenPlayer>())
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
