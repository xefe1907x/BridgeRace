using UnityEngine;

public class CollectedBricksController : MonoBehaviour
{    
    public GameObject playerBrickHolder;

    public int bluePlayerBricks = 0;
    public int redPlayerBricks = 0;
    public int greenPlayerBricks = 0;
    public int yellowPlayerBricks = 0;

    public static CollectedBricksController Instance;
    void Start()
    {
        Instance = this;
        PlayerControl.collectBricks += IncreaseCollectedBricks;
    }

    void Update()
    {
        PlayerBricksActivator();
    }

    void IncreaseCollectedBricks()
    {
        bluePlayerBricks += 1;
    }

    void PlayerBricksActivator()
    {
        if (bluePlayerBricks != 0)
        {
            for (int i = 0; i < bluePlayerBricks; i++)
            {
                if (playerBrickHolder.gameObject.transform.GetChild(i).gameObject.activeInHierarchy == false)
                {
                    playerBrickHolder.gameObject.transform.GetChild(i).gameObject.SetActive(true);
                }
            }
            
            for (int j = playerBrickHolder.gameObject.transform.childCount - 1; j > bluePlayerBricks-1; j--)
            {
                if (playerBrickHolder.gameObject.transform.GetChild(j).gameObject.activeInHierarchy)
                {
                    playerBrickHolder.gameObject.transform.GetChild(j).gameObject.SetActive(false);
                }
            }
        }
        
        else if (bluePlayerBricks == 0)
        {
            for (int i = playerBrickHolder.gameObject.transform.childCount - 1; i >= 0; i--)
            {
                if (playerBrickHolder.gameObject.transform.GetChild(i).gameObject.activeInHierarchy)
                {
                    playerBrickHolder.gameObject.transform.GetChild(i).gameObject.SetActive(false);
                }
            }
        }
    }

    void OnDisable()
    {
        PlayerControl.collectBricks -= IncreaseCollectedBricks;
    }
}
