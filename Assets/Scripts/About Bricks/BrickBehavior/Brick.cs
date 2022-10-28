using UnityEngine;

public class Brick : MonoBehaviour
{
    public bool isTaken;

    protected virtual void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Player>())
            isTaken = true;
    }
}
