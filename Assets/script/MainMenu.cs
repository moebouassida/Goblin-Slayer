using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public string levelToLoad;

    public GameObject settingsWindow;

    public static MainMenu instance;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("Il ya plus d'une instance de MainMenu dans la scène");
            return;
        }
        instance = this;
    }


    public void StartGame()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(levelToLoad);
    }

    public void SettingsButton()
    {
        settingsWindow.SetActive(true);
    }

    public void CloseSettingsWindow()
    {
        settingsWindow.SetActive(false);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

}
