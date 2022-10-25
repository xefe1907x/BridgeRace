using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.AI;

public class BotController : MonoBehaviour
{
    Animator animator;
    
    public List<Brick> brickList = new List<Brick>();

    float brickListTimer = 0.5f;

    Transform target;
    NavMeshAgent navMeshAgent;
    
    float chaseRange = 15f;
    float distanceToTarget = Mathf.Infinity;

    bool canBotMove = true;
    
    void Start()
    {
        animator = GetComponent<Animator>();
        navMeshAgent = GetComponent<NavMeshAgent>();
        Invoke(nameof(AddBricksToList), brickListTimer);
    }

    void Update()
    {
        FindTarget();
        DistanceCalculator();
        BotMovement();
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
