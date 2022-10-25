using System.Collections;
using System.Linq;
using UnityEngine;

public class RedPlayer : Player
{
    public Animator botAnimator;

    int botMoveTimer = 1;

    IEnumerator PlayerMovementActivator()
    {
        yield return new WaitForSeconds(botMoveTimer);

        // TODO: BotController ata, çarptığında hareket etmesini engellediğin colusionda burda tekrar başlat
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<BluePlayer>())
        {
            if (CollectedBricksController.Instance.bluePlayerBricks >
                CollectedBricksController.Instance.redPlayerBricks)
            {
                botAnimator.SetTrigger("onHit");
                // TODO: BotController ata, çarptığında hareket etmesini engelle
                CollectedBricksController.Instance.redPlayerBricks = 0;
                StartCoroutine(nameof(PlayerMovementActivator));
            }
        }

        if (collision.gameObject.GetComponent<GreenPlayer>())
        {
            if (CollectedBricksController.Instance.greenPlayerBricks >
                CollectedBricksController.Instance.redPlayerBricks)
            {
                botAnimator.SetTrigger("onHit");
                // TODO: BotController ata, çarptığında hareket etmesini engelle
                CollectedBricksController.Instance.redPlayerBricks = 0;
                StartCoroutine(nameof(PlayerMovementActivator));
            }
        }

        if (collision.gameObject.GetComponent<YellowPlayer>())
        {
            if (CollectedBricksController.Instance.yellowPlayerBricks >
                CollectedBricksController.Instance.redPlayerBricks)
            {
                botAnimator.SetTrigger("onHit");
                // TODO: BotController ata, çarptığında hareket etmesini engelle
                CollectedBricksController.Instance.redPlayerBricks = 0;
                StartCoroutine(nameof(PlayerMovementActivator));
            }
        }
    }
    
}
