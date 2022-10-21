using System.Collections;
using DG.Tweening;
using UnityEngine;

public class GateDoorOpener : MonoBehaviour
{
    float doorTargetScale = 0.3f;
    float doorOpenTime = 1.5f;
    void Start()
    {
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
            gameObject.transform.DOScaleZ(doorTargetScale, doorOpenTime);
            StartCoroutine(nameof(OpenedDoorDestroyer));
        }
    }
}
