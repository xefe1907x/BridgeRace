using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] Transform target;

    [SerializeField] Vector3 offset;

    void LateUpdate()
    {
        CameraFollowsPlayer();
    }
    void CameraFollowsPlayer()
    {
        transform.position = target.position + offset;
    }
}
