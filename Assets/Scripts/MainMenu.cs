using UnityEngine;
using UnityEngine.UI;

public class MainMenuUI : MonoBehaviour
{
    public Button startButton;
    public Button exitButton;
    public string gameplaySceneName = "GameplayScene";

    void Start()
    {
        startButton.onClick.AddListener(() => {
            GameManager.Instance.StartGame(gameplaySceneName);
        });

        exitButton.onClick.AddListener(() => {
            GameManager.Instance.ExitGame();
        });
    }
}
