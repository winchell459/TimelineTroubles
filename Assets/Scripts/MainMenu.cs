using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private string GameSceneName = "Game", CreditsSceneName = "Credits", SettingsSceneName = "Settings";
    public QuestHandler QH;
    public void StartGameButton()
    {
        QH.ResetQuests();
        LoadScene(GameSceneName);
    }

    public void CreditsButton()
    {
        LoadScene(CreditsSceneName);
    }

    public void SettingsButton()
    {
        LoadScene(SettingsSceneName);
    }

    private void LoadScene(string sceneName)
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(sceneName);
    }

}
