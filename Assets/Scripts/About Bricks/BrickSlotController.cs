using UnityEngine;

[DefaultExecutionOrder(-100)]
public class BrickSlotController : MonoBehaviour
{
    public GameObject greenBrick;
    public GameObject blueBrick;
    public GameObject redBrick;
    public GameObject yellowBrick;

    int brickNumber; // 1 = Green,  2 = Blue,  3 = Red,  4 = Yellow

    void Awake()
    {
        RandomNumberCreator();
        BrickInstantiator();
    }
    
    void RandomNumberCreator()
    {
        brickNumber = Random.Range(1, 5);
    }

    void BrickInstantiator()
    {
        GameObject brick = null;

        switch (brickNumber)
        {
            case 1:
                brick = Instantiate(greenBrick, transform);
                brick.SetActive(false);
                break;

            case 2:
                brick = Instantiate(blueBrick, transform);
                brick.SetActive(false);
                break;

            case 3:
                brick = Instantiate(redBrick, transform);
                brick.SetActive(false);
                break;

            case 4:
                brick = Instantiate(yellowBrick, transform);
                brick.SetActive(false);
                break;
        }
    }
}
