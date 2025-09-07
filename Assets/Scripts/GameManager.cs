using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public string mainMenuSceneName = "MainMenu";

    void Awake()
    {
        if (Instance == null) Instance = this; else Destroy(gameObject);
        DontDestroyOnLoad(gameObject);
    }

    public void OnPlayerCaught()
    {
        Debug.Log("Player catturato! Game Over.");
        SceneManager.LoadScene(mainMenuSceneName);
    }

    public void StartGame(string gameplayScene)
    {
        SceneManager.LoadScene(gameplayScene);
    }

    public void ExitGame()
    {
        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
        #else
            Application.Quit();
        #endif
    }
}
