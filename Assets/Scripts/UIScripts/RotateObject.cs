using UnityEngine;

public class RotateObject : MonoBehaviour
{
    private float forcePower = 18f;
    void Update()
    {
        RotateGameObject();
    }

    void RotateGameObject()
    {
        transform.Rotate(0f,0f,0f + forcePower * Time.deltaTime);
    }
}
