using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class PlayerController : MonoBehaviour
{
    float _initialSpeed = 4f;
    float _speed;
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

        if (Input.GetMouseButton(0) || Input.GetKey(KeyCode.LeftShift))
        {
            _speed = _initialSpeed * 2; // Raddoppia la velocità
        }
        else
        {
            _speed = _initialSpeed;
        }
            Vector3 target = transform.position + inputDirection * 1.5f;
            agent.speed = _speed;
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
