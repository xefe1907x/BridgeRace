using System.Collections;
using System.Linq;
using UnityEngine;

public class GreenPlayer : Player
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
        if (collision.gameObject.GetComponent<RedPlayer>())
        {
            if (CollectedBricksController.Instance.redPlayerBricks >
                CollectedBricksController.Instance.greenPlayerBricks)
            {
                botAnimator.SetTrigger("onHit");
                // TODO: BotController ata, çarptığında hareket etmesini engelle
                CollectedBricksController.Instance.greenPlayerBricks = 0;
                StartCoroutine(nameof(PlayerMovementActivator));
            }
        }

        if (collision.gameObject.GetComponent<BluePlayer>())
        {
            if (CollectedBricksController.Instance.bluePlayerBricks >
                CollectedBricksController.Instance.greenPlayerBricks)
            {
                botAnimator.SetTrigger("onHit");
                // TODO: BotController ata, çarptığında hareket etmesini engelle
                CollectedBricksController.Instance.greenPlayerBricks = 0;
                StartCoroutine(nameof(PlayerMovementActivator));
            }
        }

        if (collision.gameObject.GetComponent<BluePlayer>())
        {
            if (CollectedBricksController.Instance.bluePlayerBricks >
                CollectedBricksController.Instance.greenPlayerBricks)
            {
                botAnimator.SetTrigger("onHit");
                // TODO: BotController ata, çarptığında hareket etmesini engelle
                CollectedBricksController.Instance.greenPlayerBricks = 0;
                StartCoroutine(nameof(PlayerMovementActivator));
            }
        }
    }

}
