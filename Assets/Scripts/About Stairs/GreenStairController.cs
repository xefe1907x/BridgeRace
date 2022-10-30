using System;
using UnityEngine;

public class GreenStairController : MonoBehaviour
{
    float moveTreshHold = 0.63f;

    public static Action greenBricksAreZero;
    
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<Player>())
        {
            if (other.gameObject.GetComponent<GreenPlayer>())
            {
                if (CollectedBricksController.Instance.greenPlayerBricks > 0)
                {
                    gameObject.transform.position = new Vector3(transform.position.x, transform.position.y,
                        transform.position.z + moveTreshHold);
                    
                    CollectedBricksController.Instance.greenPlayerBricks -= 1;
                    
                    if (CollectedBricksController.Instance.greenPlayerBricks == 0)
                    {
                        greenBricksAreZero.Invoke();
                    }
                }
            }
            
            // else if (other.gameObject.GetComponent<RedPlayer>())
            // {
            //     gameObject.GetComponent<BoxCollider>().isTrigger = true;
            // }
            //
            // else if (other.gameObject.GetComponent<BluePlayer>())
            // {
            //     gameObject.GetComponent<BoxCollider>().isTrigger = true;
            // }
            //
            // else if (other.gameObject.GetComponent<YellowPlayer>())
            // {
            //     gameObject.GetComponent<BoxCollider>().isTrigger = true;
            // }
        }
    }
}
