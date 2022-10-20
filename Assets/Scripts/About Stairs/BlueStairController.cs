using System;
using UnityEngine;

public class BlueStairController : MonoBehaviour
{
    //TODO: Belli bir aşama geri gittikten sonra, kapıya ulaştıktan sonra bu objeyi setactive false yap
    float moveTreshHold = 0.63f;
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<Player>())
        {
            if (collision.gameObject.GetComponent<BluePlayer>())
            {
                if (CollectedBricksController.bluePlayerBricks > 0)
                {
                    gameObject.transform.position = new Vector3(transform.position.x, transform.position.y,
                        transform.position.z + moveTreshHold);
                    
                    CollectedBricksController.bluePlayerBricks -= 1;
                }
            }
            
            else if (collision.gameObject.GetComponent<RedPlayer>())
            {
                gameObject.GetComponent<BoxCollider>().isTrigger = true;
            }
            
            else if (collision.gameObject.GetComponent<GreenPlayer>())
            {
                // green Playerin yapacakları
            }
            
            else if (collision.gameObject.GetComponent<YellowPlayer>())
            {
                // yellow Playerin yapacakları
            }
        }
    }

    void OnTriggerExit(Collider other)
    {
        gameObject.GetComponent<BoxCollider>().isTrigger = false;
    }
}
