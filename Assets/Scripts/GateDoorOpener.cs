using System.Collections;
using DG.Tweening;
using UnityEngine;

public class GateDoorOpener : MonoBehaviour
{
    AudioSource audioSource;
    public AudioClip openGateSound;
    
    float doorTargetScale = 0.3f;
    float doorOpenTime = 1.5f;

    public GameObject cannotPass;
    void Start()
    {
        audioSource = gameObject.GetComponent<AudioSource>();
        DOTween.Init();
    }

    IEnumerator OpenedDoorDestroyer()
    {
        yield return new WaitForSeconds(doorOpenTime);
        
        gameObject.SetActive(false);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<Player>())
        {
            if (cannotPass.gameObject.activeInHierarchy)
            {
                cannotPass.gameObject.SetActive(false);
                audioSource.PlayOneShot(openGateSound);
            }
            gameObject.transform.DOScaleZ(doorTargetScale, doorOpenTime);
            StartCoroutine(nameof(OpenedDoorDestroyer));
        }
    }
}
