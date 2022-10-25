using UnityEngine;

public class YellowBrick : Brick
{
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<YellowPlayer>())
        {
            gameObject.SetActive(false);
        }
    }
}
