using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class StationaryEnemy : EnemyBase
{
    public float rotateInterval = 2f;
    public float rotateAngle = 90f;
    float timer;

    protected override void Awake()
    {
        base.Awake();
        currentState = State.Idle;
        agent.isStopped = true;
    }

    protected override void StateUpdate()
    {
        if (currentState == State.Chase)
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
            if (!agent.pathPending && agent.remainingDistance < 0.5f)
            {
                currentState = State.Idle;
                agent.isStopped = true;
            }
        }
        else
        {
            agent.isStopped = true;
            timer += Time.deltaTime;
            if (timer >= rotateInterval)
            {
                transform.Rotate(0f, rotateAngle, 0f);
                timer = 0f;
            }
        }

        if (player != null && Vector3.Distance(transform.position, player.position) < 1.0f)
        {
            CatchPlayer();
        }
    }
}
