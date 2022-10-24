using System.Collections;
using UnityEngine;

public class BlueBrick : Brick
{
    public GameObject[] trails;

    float trailCloserTime = 0.4f;
    void OnEnable()
    {
        StartCoroutine(nameof(TrailCloser));
    }

    IEnumerator TrailCloser()
    {
        yield return new WaitForSeconds(trailCloserTime);

        foreach (var trail in trails)
        {
            trail.SetActive(false);
        }
    }
}
