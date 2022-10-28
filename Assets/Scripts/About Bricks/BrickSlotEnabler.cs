using UnityEngine;

[DefaultExecutionOrder(1000)]
public class BrickSlotEnabler : MonoBehaviour
{
  
    protected virtual void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<RedPlayer>())
        {
            var bricks = GetComponentsInChildren<RedBrick>(true);
            foreach (var brick in bricks)
                brick.gameObject.SetActive(true);
        }
        if (other.GetComponent<GreenPlayer>())
        {
            var bricks = GetComponentsInChildren<GreenBrick>(true);
            foreach (var brick in bricks)
                brick.gameObject.SetActive(true);
        }
        if (other.GetComponent<YellowPlayer>())
        {
            var bricks = GetComponentsInChildren<YellowBrick>(true);
            foreach (var brick in bricks)
                brick.gameObject.SetActive(true);
        }
        if (other.GetComponent<BluePlayer>())
        {
            var bricks = GetComponentsInChildren<BlueBrick>(true);
            foreach (var brick in bricks)
                brick.gameObject.SetActive(true);
        }
    }
}
