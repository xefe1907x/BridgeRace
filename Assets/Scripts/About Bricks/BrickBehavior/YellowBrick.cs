using System;
using UnityEngine;

public class YellowBrick : Brick
{
    public static Action yellowBrickCollect;
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<YellowPlayer>())
        {
            yellowBrickCollect.Invoke();
            gameObject.SetActive(false);
        }
    }
}
