using UnityEngine;
using UnityEngine.AI;
using Unity.AI.Navigation;

public class InteractableButton : MonoBehaviour
{
    public KeyCode interactKey = KeyCode.E;
    public float interactionRange = 2f;
    public DoorController doorToToggle;
    public Canvas worldPrompt;
    Transform player;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        if (worldPrompt) worldPrompt.gameObject.SetActive(false);
    }

    void Update()
    {
        if (player == null) return;
        float dist = Vector3.Distance(transform.position, player.position);
        if (dist <= interactionRange)
        {
            if (worldPrompt) worldPrompt.gameObject.SetActive(true);
            if (Input.GetKeyDown(interactKey))
            {
                Toggle();
            }
        }
        else
        {
            if (worldPrompt) worldPrompt.gameObject.SetActive(false);
        }
    }

    void Toggle()
    {
        if (doorToToggle != null)
        {
            doorToToggle.ToggleDoor();
            Debug.Log("Pulsante premuto, stato porta: " + (doorToToggle.isOpen ? "Aperta" : "Chiusa"));
        }
        else Debug.LogWarning("Nessuna porta assegnata al pulsante.");
    }
}
