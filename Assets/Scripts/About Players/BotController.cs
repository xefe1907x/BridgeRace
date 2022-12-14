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
    float chaseRange = 35f;
    Transform _target;

    public static Action loseGame;

    bool isInBottom = true;
    bool isInMiddle;
    bool isInTop;

    public GameObject bottom;
    public GameObject middle;
    public GameObject top;
    NavMeshAgent agent;

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
        agent = GetComponent<NavMeshAgent>();
        
        if (gameObject.GetComponent<RedPlayer>())
            RedStairController.redBricksAreZero += TargetToBricksAgain;
        if (gameObject.GetComponent<YellowPlayer>())
            YellowStairController.yellowBricksAreZero += TargetToBricksAgain;
        if (gameObject.GetComponent<GreenPlayer>())
            GreenStairController.greenBricksAreZero += TargetToBricksAgain;
        InvokeRepeating("SetDestination", 0.1f, 0.1f);
        Invoke("FindTarget", 0.5f);
        animator.SetBool("isRunning", true);
    }

    void Update()
    {
        TargetChangerAfterCollectBrick();
    }

    void SetDestination()
    {
        if (_target != null)
            agent.SetDestination(_target.position);
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
            if (CollectedBricksController.Instance.redPlayerBricks == 9)
            {
                botNeedToGoStairs = true;
            }
        }
        
        if (gameObject.GetComponent<GreenPlayer>())
        {
            if (CollectedBricksController.Instance.greenPlayerBricks == 10)
            {
                botNeedToGoStairs = true;
            }
        }
        
        if (gameObject.GetComponent<YellowPlayer>())
        {
            if (CollectedBricksController.Instance.greenPlayerBricks == 11)
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
                        _target = brickList[i].transform;
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
                    _target = stair1End1;
                }

                else if (botChooseStairs == 2)
                {
                    _target = stair1End2;
                }

                else
                {
                    _target = stair1End3;
                }
            }
                
            else if (isInMiddle)
            {
                if (botChooseStairs2 == 1)
                {
                    _target = stair2End1;
                }
                    
                else
                {
                    _target = stair2End2;
                }
            }
                
            else if (isInTop)
            {
                _target = stair3End;
            }
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
        }
        
        else if (gameObject.GetComponent<YellowPlayer>())
        {
            brickList.Clear();
            if (isInBottom)
            {
                var bricks = bottom.GetComponentsInChildren<YellowBrick>().ToList();
                brickList = bricks.Cast<Brick>().ToList();
            }
            else if (isInMiddle)
            {
                var bricks = middle.GetComponentsInChildren<YellowBrick>().ToList();
                brickList = bricks.Cast<Brick>().ToList();
            }
            else
            {
                var bricks = top.GetComponentsInChildren<YellowBrick>().ToList();
                brickList = bricks.Cast<Brick>().ToList();
            }
        }
        
        else if (gameObject.GetComponent<GreenPlayer>())
        {
            brickList.Clear();
            if (isInBottom)
            {
                var bricks = bottom.GetComponentsInChildren<GreenBrick>().ToList();
                brickList = bricks.Cast<Brick>().ToList();
            }
            else if (isInMiddle)
            {
                var bricks = middle.GetComponentsInChildren<GreenBrick>().ToList();
                brickList = bricks.Cast<Brick>().ToList();
            }
            else
            {
                var bricks = top.GetComponentsInChildren<GreenBrick>().ToList();
                brickList = bricks.Cast<Brick>().ToList();
            }
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
        if (gameObject.GetComponent<RedPlayer>())
        {
            if (other.gameObject.GetComponent<RedBrick>())
            {
                Invoke("FindTarget", 0.1f);
            }
            
        }
        
        if (gameObject.GetComponent<YellowPlayer>())
        {
            if (other.gameObject.GetComponent<YellowBrick>())
                FindTarget();
        }
        
        if (gameObject.GetComponent<GreenPlayer>())
        {
            if (other.gameObject.GetComponent<GreenBrick>())
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
        
        if (other.CompareTag("Finish"))
        {
            loseGame?.Invoke();
        }
    }
}
