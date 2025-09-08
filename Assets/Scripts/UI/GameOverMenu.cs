using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverMenu : MonoBehaviour
{
    public void RestartGame()
    {
        Time.timeScale = 1f; // Riprende il gioco
        SceneManager.LoadScene("Level1");
    }

    public void GoToHomeMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
