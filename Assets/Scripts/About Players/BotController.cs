using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.AI;
using Random = UnityEngine.Random;

public class BotController : MonoBehaviour
{
    Animator animator;
    
    public List<Brick> brickList = new List<Brick>();

    float brickListTimer = 0.5f;
    float chaseRange = 15f;
    float distanceToTarget = Mathf.Infinity;
    
    Transform target;
    [SerializeField] Transform stair1Entrance;
    [SerializeField] Transform stair2Entrance;
    [SerializeField] Transform stair3Entrance;

    NavMeshAgent navMeshAgent;

    int botChooseStairs;

    bool canBotMove = true;
    bool botNeedToGoStairs;

    void Start()
    {
        BotChooseStair();
        animator = GetComponent<Animator>();
        navMeshAgent = GetComponent<NavMeshAgent>();
        Invoke(nameof(AddBricksToList), brickListTimer);
    }

    void Update()
    {
        FindTarget();
        DistanceCalculator();
        BotMovement();
        TargetChangerAfterCollectBrick();
    }

    void TargetChangerAfterCollectBrick()
    {
        if (gameObject.GetComponent<RedPlayer>())
        {
            if (CollectedBricksController.Instance.redPlayerBricks == 2)
            {
                botNeedToGoStairs = true;
            }
        }
    }

    void BotChooseStair()
    {
        botChooseStairs = Random.Range(1, 4);
    }

    void FindTarget()
    {
        float nearestDistance = 15f;
        for (int i = 0; i < brickList.Count; i++)
        {
            if (brickList[i].gameObject.activeInHierarchy)
            {
                var brickDistance = Vector3.Distance(brickList[i].transform.position, transform.position);

                if (brickDistance <= nearestDistance)
                {
                    target = brickList[i].transform;
                }
            }
        }
    }
    
    void BotMovement()
    {
        if (canBotMove)
        {
            if (!botNeedToGoStairs)
            {
                if (target != null)
                {
                    if (distanceToTarget <= chaseRange)
                    {
                        navMeshAgent.SetDestination(target.position);
                        animator.SetBool("isRunning", true);
                    }
                }
                else
                {
                    animator.SetBool("isRunning", false);
                }
            }

            else
            {
                if (botChooseStairs == 1)
                {
                    target = stair1Entrance;
                    navMeshAgent.SetDestination(target.position);
                }
                
                else if (botChooseStairs == 2)
                {
                    target = stair2Entrance;
                    navMeshAgent.SetDestination(target.position);
                }

                else
                {
                    target = stair3Entrance;
                    navMeshAgent.SetDestination(target.position);
                }
            }
        }
    }

    void DistanceCalculator()
    {
        if (target != null)
        {
            distanceToTarget = Vector3.Distance(target.position, transform.position);
        }
    }

    void AddBricksToList()
    {
        if (gameObject.GetComponent<RedPlayer>())
        {
            brickList = FindObjectsOfType<RedBrick>().Cast<Brick>().ToList();
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
}
