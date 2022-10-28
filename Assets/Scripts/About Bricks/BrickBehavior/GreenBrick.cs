using System;
using UnityEngine;

public class GreenBrick : Brick
{
    public static Action greenBrickCollect;

    protected override void OnTriggerEnter(Collider other)
    {
        base.OnTriggerEnter(other);
        if (other.gameObject.GetComponent<GreenPlayer>())
        {
            greenBrickCollect.Invoke();
            gameObject.SetActive(false);
        }
    }
}
