using UnityEngine;
using UnityEngine.AI;

public class PatrolEnemy : EnemyBase
{
    public Transform[] patrolPoints;
    public float pointReachedThreshold = 0.5f;
    int currentPoint = 0;

    protected override void Awake()
    {
        base.Awake();
        currentState = State.Patrol;
        if (patrolPoints == null || patrolPoints.Length == 0)
            currentState = State.Idle;
    }

    protected override void StateUpdate()
    {
        if (currentState == State.Patrol)
        {
            agent.isStopped = false;
            if (patrolPoints.Length == 0) return;
            agent.SetDestination(patrolPoints[currentPoint].position);

            if (!agent.pathPending && agent.remainingDistance < pointReachedThreshold)
            {
                currentPoint = (currentPoint + 1) % patrolPoints.Length;
            }
        }
        else if (currentState == State.Chase)
        {
            agent.isStopped = false;
            agent.SetDestination(lastKnownPlayerPos);

            if (!agent.pathPending && agent.remainingDistance < 0.5f)
            {
                ExitChase();
            }
        }
        else if (currentState == State.Return)
        {
            agent.isStopped = false;
            agent.SetDestination(patrolPoints[currentPoint].position);
            if (!agent.pathPending && agent.remainingDistance < pointReachedThreshold)
            {
                currentState = State.Patrol;
            }
        }

        if (player != null && Vector3.Distance(transform.position, player.position) < 1.0f)
        {
            CatchPlayer();
        }
    }
}
