using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] Transform target;

    [SerializeField] Vector3 offset;

    void LateUpdate()
    {
        CameraFollowsPlayer();
    }

    // 3.13   19.37   -28.18
    void CameraFollowsPlayer()
    {
        transform.position = target.position + offset;
    }
}
