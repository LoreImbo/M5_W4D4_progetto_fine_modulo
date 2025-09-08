using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public abstract class EnemyBase : MonoBehaviour
{
    public enum State { Idle, Patrol, Chase, Return }
    public State currentState = State.Idle;

    [Header("References")]
    public Transform player;
    protected NavMeshAgent agent;
    protected Vector3 lastKnownPlayerPos;

    [Header("Vision")]
    public FieldOfView fov;

    [Header("Return")]
    protected Vector3 previousPositionBeforeChase;

    protected virtual void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        if (player == null)
            player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    protected virtual void Update()
    {
        if (fov != null && player != null && fov.CanSeeTarget(player))
        {
            lastKnownPlayerPos = player.position;
            if (currentState != State.Chase)
            {
                EnterChase();
            }
        }

        StateUpdate();
    }

    protected abstract void StateUpdate();

    protected virtual void EnterChase()
    {
        previousPositionBeforeChase = transform.position;
        currentState = State.Chase;
        agent.SetDestination(lastKnownPlayerPos);
    }

    protected virtual void ExitChase()
    {
        currentState = State.Return;
        agent.SetDestination(previousPositionBeforeChase);
    }

    protected void CatchPlayer()
    {
        GameManager.Instance.OnPlayerCaught();
    }
}
