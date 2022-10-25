using UnityEngine;

public class GreenBrick : Brick
{
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<GreenPlayer>())
        {
            gameObject.SetActive(false);
        }
    }
}
