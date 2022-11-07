using System;
using UnityEngine;

public class CollectedBricksController : MonoBehaviour
{    
    public GameObject playerBrickHolder;
    public GameObject redBotBrickHolder;
    public GameObject greenBotBrickHolder;
    public GameObject yellowBotBrickHolder;

    public int bluePlayerBricks = 0;
    public int redPlayerBricks = 0;
    public int greenPlayerBricks = 0;
    public int yellowPlayerBricks = 0;

    #region Singleton
    
    public static CollectedBricksController Instance;

    void Awake()
    {
        if (Instance != null)
            Destroy(Instance);

        Instance = this;
    }
    
    #endregion

    void Start()
    {
        PlayerControl.Instance.collectBricks += IncreaseCollectedBlueBricks;
        RedBrick.redBrickCollect += IncreaseCollectedRedBricks;
        GreenBrick.greenBrickCollect += IncreaseCollectedGreenBricks;
        YellowBrick.yellowBrickCollect += IncreaseCollectedYellowBricks;
    }

    void Update()
    {
        PlayerBricksActivator();
        RedBotBricksActivator();
        YellowBotBricksActivator();
        GreenBotBricksActivator();
    }

    void GreenBotBricksActivator()
    {
        if (greenPlayerBricks != 0)
        {
            for (int i = 0; i < greenPlayerBricks; i++)
            {
                if (greenBotBrickHolder.gameObject.transform.GetChild(i).gameObject.activeInHierarchy == false)
                {
                    greenBotBrickHolder.gameObject.transform.GetChild(i).gameObject.SetActive(true);
                }
            }
            
            for (int j = greenBotBrickHolder.gameObject.transform.childCount - 1; j > greenPlayerBricks-1; j--)
            {
                if (greenBotBrickHolder.gameObject.transform.GetChild(j).gameObject.activeInHierarchy)
                {
                    greenBotBrickHolder.gameObject.transform.GetChild(j).gameObject.SetActive(false);
                }
            }
        }
        
        else if (greenPlayerBricks == 0)
        {
            for (int i = greenBotBrickHolder.gameObject.transform.childCount - 1; i >= 0; i--)
            {
                if (greenBotBrickHolder.gameObject.transform.GetChild(i).gameObject.activeInHierarchy)
                {
                    greenBotBrickHolder.gameObject.transform.GetChild(i).gameObject.SetActive(false);
                }
            }
        }
    }
    void YellowBotBricksActivator()
    {
        if (yellowPlayerBricks != 0)
        {
            for (int i = 0; i < yellowPlayerBricks; i++)
            {
                if (yellowBotBrickHolder.gameObject.transform.GetChild(i).gameObject.activeInHierarchy == false)
                {
                    yellowBotBrickHolder.gameObject.transform.GetChild(i).gameObject.SetActive(true);
                }
            }
            
            for (int j = yellowBotBrickHolder.gameObject.transform.childCount - 1; j > yellowPlayerBricks-1; j--)
            {
                if (yellowBotBrickHolder.gameObject.transform.GetChild(j).gameObject.activeInHierarchy)
                {
                    yellowBotBrickHolder.gameObject.transform.GetChild(j).gameObject.SetActive(false);
                }
            }
        }
        
        else if (yellowPlayerBricks == 0)
        {
            for (int i = yellowBotBrickHolder.gameObject.transform.childCount - 1; i >= 0; i--)
            {
                if (yellowBotBrickHolder.gameObject.transform.GetChild(i).gameObject.activeInHierarchy)
                {
                    yellowBotBrickHolder.gameObject.transform.GetChild(i).gameObject.SetActive(false);
                }
            }
        }
    }
    void RedBotBricksActivator()
    {
        if (redPlayerBricks != 0)
        {
            for (int i = 0; i < redPlayerBricks; i++)
            {
                if (redBotBrickHolder.gameObject.transform.GetChild(i).gameObject.activeInHierarchy == false)
                {
                    redBotBrickHolder.gameObject.transform.GetChild(i).gameObject.SetActive(true);
                }
            }
            
            for (int j = redBotBrickHolder.gameObject.transform.childCount - 1; j > redPlayerBricks-1; j--)
            {
                if (redBotBrickHolder.gameObject.transform.GetChild(j).gameObject.activeInHierarchy)
                {
                    redBotBrickHolder.gameObject.transform.GetChild(j).gameObject.SetActive(false);
                }
            }
        }
        
        else if (redPlayerBricks == 0)
        {
            for (int i = redBotBrickHolder.gameObject.transform.childCount - 1; i >= 0; i--)
            {
                if (redBotBrickHolder.gameObject.transform.GetChild(i).gameObject.activeInHierarchy)
                {
                    redBotBrickHolder.gameObject.transform.GetChild(i).gameObject.SetActive(false);
                }
            }
        }
    }

    void IncreaseCollectedBlueBricks()
    {
        bluePlayerBricks += 1;
    }
    
    void IncreaseCollectedRedBricks()
    {
        redPlayerBricks += 1;
    }
    
    void IncreaseCollectedGreenBricks()
    {
        greenPlayerBricks += 1;
    }
    
    void IncreaseCollectedYellowBricks()
    {
        yellowPlayerBricks += 1;
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
        PlayerControl.Instance.collectBricks -= IncreaseCollectedBlueBricks;
        RedBrick.redBrickCollect -= IncreaseCollectedRedBricks;
        GreenBrick.greenBrickCollect -= IncreaseCollectedGreenBricks;
        YellowBrick.yellowBrickCollect -= IncreaseCollectedYellowBricks;
    }
}
