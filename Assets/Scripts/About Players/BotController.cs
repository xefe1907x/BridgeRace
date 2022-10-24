using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class BotController : MonoBehaviour
{
    public List<Brick> brickList = new List<Brick>();

    void Start()
    {
        AddBricksToList();
    }

    void AddBricksToList()
    {
        if (gameObject.GetComponent<RedPlayer>())
        {
            brickList = FindObjectsOfType<RedBrick>().Cast<Brick>().ToList();
        }
    }
}
