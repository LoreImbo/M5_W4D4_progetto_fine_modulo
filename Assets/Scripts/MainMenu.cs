using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void StartGame()
    {
        Time.timeScale = 1f; // Assicura che il gioco parta con il tempo normale
        SceneManager.LoadScene("Level1");
    }

    public void QuitGame()
    {
        Debug.Log("Uscita dal gioco");
    }
}
