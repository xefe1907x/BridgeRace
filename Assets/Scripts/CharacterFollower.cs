using UnityEngine;

public class CharacterFollower : MonoBehaviour
{
    public Transform characterPosition;

    void LateUpdate()
    {
        transform.position = characterPosition.transform.position;
    }
}
