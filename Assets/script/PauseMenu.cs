using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool gameIsPaused = false;

    public GameObject pauseMenuUI;

    public GameObject settingsWindow;

    public AudioSource audioSource;

   

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if(gameIsPaused)
            {
                Resume();
               
            }
            else
            {
                
                Paused();
          
            }
        }
    }

    void Paused()
    {
        switch (SceneManager.GetActiveScene().name)
        {
            case "Level01":
                Playermovement.instance.enabled = false;
                break;
            
            
            case "Level02":
                PlayerMovement02.instance.enabled = false;
                break;
            
            
            case "Level03":
                PlayerMovement02.instance.enabled = false;
                break;
            
            
            case "Level04" :
                PlayerMovement04.instance.enabled = false;
                break;

           
            case "Level05":
                PlayerMovement04.instance.enabled = false;
                break;
        }
        
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0;
        gameIsPaused = true;
        audioSource.Pause();

    }

    public void Resume()
    {
        switch (SceneManager.GetActiveScene().name)
        {
            case "Level01":
                Playermovement.instance.enabled = true;
                break;


            case "Level02":
                PlayerMovement02.instance.enabled = true;
                break;


            case "Level03":
                PlayerMovement02.instance.enabled = true;
                break;


            case "Level04":
                PlayerMovement04.instance.enabled = true;
                break;


            case "Level05":
                PlayerMovement04.instance.enabled = true;
                break;
        }

        pauseMenuUI.SetActive(false);
        Time.timeScale = 1;
        gameIsPaused = false;
        audioSource.Play();
    }

    public void LoadMainMenu()
    {
        Resume();
        SceneManager.LoadScene("MainMenu");
    }

    public void OpenSettingsWindow()
    {
        settingsWindow.SetActive(true);
    }

    public void CloseSettingsWindow()
    {
        settingsWindow.SetActive(false);
    }
}
