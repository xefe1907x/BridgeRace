using UnityEngine;

public class GreenStairController : MonoBehaviour
{
    float moveTreshHold = 0.63f;
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<Player>())
        {
            if (collision.gameObject.GetComponent<GreenPlayer>())
            {
                if (CollectedBricksController.greenPlayerBricks > 0)
                {
                    gameObject.transform.position = new Vector3(transform.position.x, transform.position.y,
                        transform.position.z + moveTreshHold);
                    
                    CollectedBricksController.greenPlayerBricks -= 1;
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
            
            else if (collision.gameObject.GetComponent<YellowPlayer>())
            {
                gameObject.GetComponent<BoxCollider>().isTrigger = true;
            }
        }
    }

    void OnTriggerExit(Collider other)
    {
        gameObject.GetComponent<BoxCollider>().isTrigger = false;
    }
}
