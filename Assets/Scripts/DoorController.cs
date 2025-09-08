using UnityEngine;
using UnityEngine.AI;

public class DoorController : MonoBehaviour
{
    public bool isOpen = false;
    public Vector3 openOffset = new Vector3(0, 2f, 0);
    public float openSpeed = 3f;

    Vector3 closedPos;
    Vector3 openPos;
    private NavMeshObstacle obstacle;


    void Start()
    {
        closedPos = transform.position;
        openPos = closedPos + openOffset;
        obstacle = GetComponent<NavMeshObstacle>();

    }

    void Update()
    {
        transform.position = Vector3.Lerp(transform.position, isOpen ? openPos : closedPos, Time.deltaTime * openSpeed);
    }

    public void ToggleDoor()
    {
        isOpen = !isOpen;


        if (obstacle != null)
        {
            // Quando la porta è aperta, disabilito l’ostacolo
            obstacle.enabled = !isOpen;
        }
        else
        {
            Debug.LogWarning("NavMeshObstacle non trovato sulla porta.");
        }
    }
}
