using System;
using UnityEngine;

public class YellowBrick : Brick
{
    public static Action yellowBrickCollect;
    protected override void OnTriggerEnter(Collider other)
    {
        base.OnTriggerEnter(other);
        if (other.gameObject.GetComponent<YellowPlayer>())
        {
            yellowBrickCollect.Invoke();
            gameObject.SetActive(false);
        }
    }
}
