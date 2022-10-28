using System;
using UnityEngine;

public class RedBrick : Brick
{
    public static Action redBrickCollect;
    protected override void OnTriggerEnter(Collider other)
    {
        base.OnTriggerEnter(other);
        if (other.gameObject.GetComponent<RedPlayer>())
        {
            redBrickCollect.Invoke();
            gameObject.SetActive(false);
        }
    }
}
