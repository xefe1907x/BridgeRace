using System.Collections;
using UnityEngine;

public class BluePlayer : Player
{
    public Animator playerAnimator;

    int playerMoveTimer = 1;
    IEnumerator PlayerMovementActivator()
    {
        yield return new WaitForSeconds(playerMoveTimer);

        PlayerControl.Instance.playerFalse = false;
    }
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<RedPlayer>())
        {
            if (CollectedBricksController.Instance.redPlayerBricks >
                CollectedBricksController.Instance.bluePlayerBricks)
            {
                playerAnimator.SetTrigger("onHit");
                PlayerControl.Instance.playerFalse = true;
                CollectedBricksController.Instance.bluePlayerBricks = 0;
                StartCoroutine(nameof(PlayerMovementActivator));
            }
        }
        
        if (collision.gameObject.GetComponent<GreenPlayer>())
        {
            if (CollectedBricksController.Instance.greenPlayerBricks >
                CollectedBricksController.Instance.bluePlayerBricks)
            {
                playerAnimator.SetTrigger("onHit");
                PlayerControl.Instance.playerFalse = true;
                CollectedBricksController.Instance.bluePlayerBricks = 0;
                StartCoroutine(nameof(PlayerMovementActivator));
            }
        }
        
        if (collision.gameObject.GetComponent<YellowPlayer>())
        {
            if (CollectedBricksController.Instance.yellowPlayerBricks >
                CollectedBricksController.Instance.bluePlayerBricks)
            {
                playerAnimator.SetTrigger("onHit");
                PlayerControl.Instance.playerFalse = true;
                CollectedBricksController.Instance.bluePlayerBricks = 0;
                StartCoroutine(nameof(PlayerMovementActivator));
            }
        }
    }
}