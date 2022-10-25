using System.Collections;
using UnityEngine;

[DefaultExecutionOrder(1000)]
public class BrickSlotEnabler : MonoBehaviour
{
  
    protected virtual void OnTriggerEnter(Collider other)
    {
        print(other.name);
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
            print(bricks.Length + "brick lengghtdfsdf");
            foreach (var brick in bricks)
                brick.gameObject.SetActive(true);
        }
        if (other.GetComponent<BluePlayer>())
        {
            var bricks = GetComponentsInChildren<BlueBrick>(true);
            foreach (var brick in bricks)
                brick.gameObject.SetActive(true);
        }
        //StartCoroutine(nameof(CheckPlayerEnterCoroutine), other);
    }

    private IEnumerator CheckPlayerEnterCoroutine(Collider other)
    {
        yield return new WaitForSeconds(.25f);

    }
}
