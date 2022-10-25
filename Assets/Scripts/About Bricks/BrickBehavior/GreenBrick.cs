using System;
using UnityEngine;

public class GreenBrick : Brick
{
    public static Action greenBrickCollect;
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<GreenPlayer>())
        {
            greenBrickCollect.Invoke();
            gameObject.SetActive(false);
        }
    }
}
