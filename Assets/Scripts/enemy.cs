using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    public Transform player;
    public float visionRange = 15f;
    public float wanderRadius = 7f;
    public LayerMask wallLayer; // Assign your "Walls" layer here!

    private NavMeshAgent agent;
    private bool isChasing = false;
    private Vector3 lastKnownPosition;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        // Ensure the agent doesn't stop exactly on the player
        agent.stoppingDistance = 1.2f;
        Wander();
    }

    void Update()
    {
        bool canSeePlayer = LookForPlayer();

        if (canSeePlayer)
        {
            isChasing = true;
            lastKnownPosition = player.position;
            agent.SetDestination(lastKnownPosition);
        }
        else if (isChasing)
        {
            // Go to the last place I saw the player
            agent.SetDestination(lastKnownPosition);

            // If I reached the last known spot and still can't see them, stop chasing
            if (agent.remainingDistance <= agent.stoppingDistance + 0.5f)
            {
                isChasing = false;
            }
        }
        else if (agent.remainingDistance <= agent.stoppingDistance)
        {
            Wander();
        }
    }

    bool LookForPlayer()
    {
        float distanceToPlayer = Vector3.Distance(transform.position, player.position);

        if (distanceToPlayer <= visionRange)
        {
            Vector3 directionToPlayer = (player.position - transform.position).normalized;

            // RAYCAST FIX: We check if there is a wall between us and the player
            // If the ray hits a wall first, we return false.
            if (!Physics.Raycast(transform.position + Vector3.up, directionToPlayer, distanceToPlayer, wallLayer))
            {
                // Extra safety: make sure the angle is somewhat in front (optional for 360 vision)
                return true;
            }
        }
        return false;
    }

    void Wander()
    {
        Vector3 randomDirection = Random.insideUnitSphere * wanderRadius;
        randomDirection += transform.position;

        NavMeshHit navHit;
        if (NavMesh.SamplePosition(randomDirection, out navHit, wanderRadius, NavMesh.AllAreas))
        {
            agent.SetDestination(navHit.position);
        }
    }
}