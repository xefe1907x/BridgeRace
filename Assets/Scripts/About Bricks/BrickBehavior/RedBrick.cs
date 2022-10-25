using System;
using UnityEngine;

public class RedBrick : Brick
{
    public static Action redBrickCollect;
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<RedPlayer>())
        {
            redBrickCollect.Invoke();
            gameObject.SetActive(false);
        }
    }
}
