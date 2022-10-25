using UnityEngine;

public class RedBrick : Brick
{
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<RedPlayer>())
        {
            gameObject.SetActive(false);
        }
    }
}
