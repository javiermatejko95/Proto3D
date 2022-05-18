using System;
using UnityEngine;
using UnityEngine.AI;

public enum ENEMY_AI_STATE
{
    PATROLLING,
    ATTACKING,
    CHASING
}

public class EnemyAI : MonoBehaviour
{
    #region EXPOSED_FIELDS
    [Header("Configuration")]
    [SerializeField] private LayerMask whatIsGround = default;
    [SerializeField] private LayerMask whatIsPlayer = default;
    [SerializeField] private ENEMY_AI_STATE AISTATE = default;
    [Header("Patrol")]
    [SerializeField] private Vector3 walkPoint = new Vector3();
    [SerializeField] private float walkPointRange = 10f;
    [Header("Attack")]
    [SerializeField] private float timeBetweenAttacks = 1f;
    [Header("States")]
    [SerializeField] private float sightRange = 20f;
    [SerializeField] private float attackRange = 2f;
    [Header("Timer")]
    [SerializeField] private float timeBetweenChecks = 0.5f;
    #endregion

    #region PRIVATE_FIELDS
    private NavMeshAgent agent = null;
    private Transform targetPlayer = null;
    private bool walkPointSet = false;
    private bool alreadyAttackedd = false;
    private bool playerInSightRange = false;
    private bool playerInAttackRange = false;
    private float actualTime = 0f;
    private bool initialized = false;
    #endregion

    #region PRIVATE_ACTIONS
    private Action onStateApplied = null;
    #endregion

    #region UNITY_CALLS
    private void Update()
    {
        if(!initialized)
        {
            return;
        }

        CheckState();

        onStateApplied?.Invoke();        
    }
    #endregion

    #region INITIALIZATION
    public void Init(Transform targetPlayer)
    {
        this.targetPlayer = targetPlayer;
        agent = this.GetComponent<NavMeshAgent>();
        initialized = true;
    }
    #endregion

    #region PRIVATE_METHODS
    private void CheckState()
    {
        if(actualTime <= 0f)
        {
            playerInSightRange = Physics.CheckSphere(this.transform.position, sightRange, whatIsPlayer);
            playerInAttackRange = Physics.CheckSphere(this.transform.position, attackRange, whatIsPlayer);
            if (!playerInSightRange && !playerInAttackRange)
            {
                this.onStateApplied = Patrol;
            }
            if(playerInSightRange && !playerInAttackRange)
            {
                this.onStateApplied = ChasePlayer;
            }
            if(playerInSightRange && playerInAttackRange)
            {
                this.onStateApplied = AttackPlayer;
            }
            actualTime = timeBetweenChecks;
        }
        else
        {
            actualTime -= Time.deltaTime;
        }
    }

    #region PATROL
    private void Patrol()
    {
        if (!walkPointSet) 
        {
            SearchWalkPoint();
        }

        if (walkPointSet)           
        {
            agent.SetDestination(walkPoint);
        }

        Vector3 distanceToWalkPoint = transform.position - walkPoint;

        //Walkpoint reached
        if (distanceToWalkPoint.magnitude < 1f)            
        {
            walkPointSet = false;
        }
    }

    private void SearchWalkPoint()
    {
        //Calculate random point in range
        float randomZ = UnityEngine.Random.Range(-walkPointRange, walkPointRange);
        float randomX = UnityEngine.Random.Range(-walkPointRange, walkPointRange);

        walkPoint = new Vector3(transform.position.x + randomX, transform.position.y, transform.position.z + randomZ);

        if (Physics.Raycast(walkPoint, -transform.up, 2f, whatIsGround))
        {
            walkPointSet = true;
        }
    }

    #endregion

    #region CHASING
    private void ChasePlayer()
    {
        agent.SetDestination(targetPlayer.position);
    }
    #endregion

    #region ATTACKING
    private void AttackPlayer()
    {

    }
    #endregion
    #endregion
}
