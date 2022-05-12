using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;



public class GameOverMenu : MonoBehaviour
{
    public GameObject gameOverUI;

    public static GameOverMenu instance;

    public AudioClip[] playlist;
    public AudioSource audioSource;

    private void Start()
    {
        audioSource.clip = playlist[0];
    }

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("Il ya plus d'une instance de GameOverMenu dans la scène");
            return;
        }
        instance = this;
    }


    public void OnObjectsDeath()
    {
        gameOverUI.SetActive(true);
        PlayerMovement04.instance.enabled = false;
        PlayerMovement04.instance.animator.enabled = false;
        Time.timeScale = 0;
        audioSource.Play();
    }

    public void MainMenuButton()
    {
        SceneManager.LoadScene("MainMenu");
        Time.timeScale = 1;
    }

    public void QuitButton()
    {
        Application.Quit();
    }
}
