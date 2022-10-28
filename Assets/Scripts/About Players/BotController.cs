using System;
using System.Collections.Generic;
using System.Linq;
using Pathfinding;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;
using Random = UnityEngine.Random;

public class BotController : MonoBehaviour
{
    Animator animator;
    
    public List<Brick> brickList = new List<Brick>();

    float brickListTimer = 0.5f;
    float chaseRange = 35f;
    float distanceToTarget = Mathf.Infinity;
    AIDestinationSetter _aiDestinationSetter;
    Transform _target;

    bool isInBottom = true;
    bool isInMiddle;
    bool isInTop;

    public GameObject bottom;
    public GameObject middle;
    public GameObject top;
    public Transform Target
    {
        get => _target;
        set
        {
            _target = value;
            _aiDestinationSetter.target = _target;
        }
    }

    [SerializeField] Transform stair1End1;
    [SerializeField] Transform stair1End2;
    [SerializeField] Transform stair1End3;
    [SerializeField] Transform stair2End1;
    [SerializeField] Transform stair2End2;
    [SerializeField] Transform stair3End;

    int botChooseStairs;
    int botChooseStairs2;
    
    bool botNeedToGoStairs;

    void Start()
    {
        BotChooseStair();
        animator = GetComponent<Animator>();
        Invoke(nameof(AddBricksToList), brickListTimer);
        _aiDestinationSetter = GetComponent<AIDestinationSetter>();
        _aiDestinationSetter.target = Target;
        
        if (gameObject.GetComponent<RedPlayer>())
            RedStairController.redBricksAreZero += TargetToBricksAgain;
        if (gameObject.GetComponent<YellowPlayer>())
            YellowStairController.yellowBricksAreZero += TargetToBricksAgain;
        if (gameObject.GetComponent<GreenPlayer>())
            GreenStairController.greenBricksAreZero += TargetToBricksAgain;
        
        Invoke(nameof(FindTarget),0.5f);
        animator.SetBool("isRunning", true);
    }

    void Update()
    {
        DistanceCalculator();
        TargetChangerAfterCollectBrick();
        Debug.Log("Is in Bottom: " + isInBottom);
        Debug.Log("Is in Middle: " + isInMiddle);
        Debug.Log("Is in Top: " + isInTop);
    }

    void TargetToBricksAgain()
    {
        botNeedToGoStairs = false;
        FindTarget();
    }

    void TargetChangerAfterCollectBrick()
    {
        if (gameObject.GetComponent<RedPlayer>())
        {
            if (CollectedBricksController.Instance.redPlayerBricks == 8)
            {
                botNeedToGoStairs = true;
            }
        }
        
        if (gameObject.GetComponent<GreenPlayer>())
        {
            if (CollectedBricksController.Instance.greenPlayerBricks == 14)
            {
                botNeedToGoStairs = true;
            }
        }
        
        if (gameObject.GetComponent<YellowPlayer>())
        {
            if (CollectedBricksController.Instance.greenPlayerBricks == 10)
            {
                botNeedToGoStairs = true;
            }
        }
    }

    void BotChooseStair()
    {
        botChooseStairs = Random.Range(1, 4);
        botChooseStairs2 = Random.Range(1, 3);
    }

    void FindTarget()
    {
        if (!botNeedToGoStairs)
        {
            float nearestDistance = 1500f;
            for (int i = 0; i < brickList.Count; i++)
            {
                if (brickList[i].gameObject.activeInHierarchy)
                {
                    var brickDistance = Vector3.Distance(brickList[i].transform.position, transform.position);

                    if (brickDistance <= nearestDistance)
                    {
                        Target = brickList[i].transform;
                    }
                }
            }
        }

        else
        {
            if (isInBottom)
            {
                if (botChooseStairs == 1)
                {
                    Target = stair1End1;
                }

                else if (botChooseStairs == 2)
                {
                    Target = stair1End2;
                }

                else
                {
                    Target = stair1End3;
                }
            }
                
            else if (isInMiddle)
            {
                if (botChooseStairs2 == 1)
                {
                    Target = stair2End1;
                }
                    
                else
                {
                    Target = stair2End2;
                }
            }
                
            else if (isInTop)
            {
                Target = stair3End;
            }
        }
    }

    void DistanceCalculator()
    {
        if (Target != null)
        {
            distanceToTarget = Vector3.Distance(_target.position, transform.position);
        }
    }

    public void AddBricksToList()
    {
        if (gameObject.GetComponent<RedPlayer>())
        {
            brickList.Clear();
            if (isInBottom)
            {
                var bricks = bottom.GetComponentsInChildren<RedBrick>().ToList();
                brickList = bricks.Cast<Brick>().ToList();
            }
            else if (isInMiddle)
            {
                var bricks = middle.GetComponentsInChildren<RedBrick>().ToList();
                brickList = bricks.Cast<Brick>().ToList();
            }
            else
            {
                var bricks = top.GetComponentsInChildren<RedBrick>().ToList();
                brickList = bricks.Cast<Brick>().ToList();
            }
                
            //brickList = FindObjectsOfType<RedBrick>().Cast<Brick>().ToList();
        }
        
        else if (gameObject.GetComponent<YellowPlayer>())
        {
            brickList = FindObjectsOfType<YellowBrick>().Cast<Brick>().ToList();
        }
        
        else if (gameObject.GetComponent<GreenPlayer>())
        {
            brickList = FindObjectsOfType<GreenBrick>().Cast<Brick>().ToList();
        }
    }

    void OnDrawGizmosSelected()
    {
        if (gameObject.GetComponent<RedPlayer>())
        {
            Gizmos.color = Color.red;
        }
        
        else if (gameObject.GetComponent<GreenPlayer>())
        {
            Gizmos.color = Color.green;
        }
        
        else if (gameObject.GetComponent<YellowPlayer>())
        {
            Gizmos.color = Color.yellow;
        }
        Gizmos.DrawWireSphere(transform.position, chaseRange);
    }

    void OnDisable()
    {
        if (gameObject.GetComponent<RedPlayer>())
            RedStairController.redBricksAreZero -= TargetToBricksAgain;
        if (gameObject.GetComponent<YellowPlayer>())
            YellowStairController.yellowBricksAreZero -= TargetToBricksAgain;
        if (gameObject.GetComponent<GreenPlayer>())
            GreenStairController.greenBricksAreZero -= TargetToBricksAgain;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<Brick>())
        {
            FindTarget();
        }
        
        if (other.CompareTag("MiddleGate"))
        {
            isInBottom = false;
            isInMiddle = true;
            AddBricksToList();
            FindTarget();
        }

        
        if (other.CompareTag("EndGate"))
        {
            isInMiddle = false;
            isInTop = true;
            AddBricksToList();
            FindTarget();
        }
    }
}
