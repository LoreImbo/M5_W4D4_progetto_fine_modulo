using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 4f;
    NavMeshAgent agent;
    Vector3 inputDirection;

    void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false;
    }

    void Update()
    {
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");

        inputDirection = new Vector3(h, 0f, v).normalized;

        if (inputDirection.sqrMagnitude > 0.01f)
        {
            Vector3 target = transform.position + inputDirection * 1.5f;
            agent.speed = moveSpeed;
            agent.SetDestination(target);

            Quaternion look = Quaternion.LookRotation(inputDirection, Vector3.up);
            transform.rotation = Quaternion.Slerp(transform.rotation, look, Time.deltaTime * 10f);
        }
        else
        {
            agent.ResetPath();
        }
    }
}
