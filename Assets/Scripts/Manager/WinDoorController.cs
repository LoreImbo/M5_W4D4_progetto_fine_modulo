using UnityEngine;
using UnityEngine.SceneManagement;

public class WinDoorController : MonoBehaviour
{
    public void UnlockDoor()
    {
        Debug.Log("Porta sbloccata!");
        gameObject.SetActive(true);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log($"Il giocatore {other.name} ha raggiunto la porta!");
            SceneManager.LoadScene("WinMenu"); // Carica la scena del menu di vittoria
            Time.timeScale = 0f; // Ferma il gioco
        }
    }
}
