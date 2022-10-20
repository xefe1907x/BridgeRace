using UnityEngine;

public class StairControllerDestroyer : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("StairController"))
        {
            Destroy(other.gameObject);
        }
    }
}
