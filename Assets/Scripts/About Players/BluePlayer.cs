using System;
using System.Collections;
using UnityEngine;

public class BluePlayer : Player
{
    public Animator playerAnimator;

    AudioSource audioSource;
    public AudioClip fallSound;

    int playerMoveTimer = 1;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    IEnumerator PlayerMovementActivator()
    {
        yield return new WaitForSeconds(playerMoveTimer);

        PlayerControl.Instance.playerFalse = false;
    }
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<RedPlayer>())
        {
            audioSource.PlayOneShot(fallSound);

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
            audioSource.PlayOneShot(fallSound);

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
            audioSource.PlayOneShot(fallSound);

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