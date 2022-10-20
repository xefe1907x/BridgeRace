using UnityEngine;

public class StairController : MonoBehaviour
{
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<Player>())
        {
            Debug.Log("Calisiyo");
        }
    }
}
