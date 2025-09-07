using UnityEngine;

public class DoorController : MonoBehaviour
{
    public bool isOpen = false;
    public Vector3 openOffset = new Vector3(0, 2f, 0);
    public float openSpeed = 3f;

    Vector3 closedPos;
    Vector3 openPos;

    void Start()
    {
        closedPos = transform.position;
        openPos = closedPos + openOffset;
    }

    void Update()
    {
        transform.position = Vector3.Lerp(transform.position, isOpen ? openPos : closedPos, Time.deltaTime * openSpeed);
    }

    public void ToggleDoor()
    {
        isOpen = !isOpen;
    }
}
