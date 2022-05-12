using UnityEngine;
using UnityEngine.SceneManagement;

public class Level_Door1 : MonoBehaviour
{
    public LevelChanger levelChanger;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if ( collision.CompareTag("Player") )
        {
            levelChanger.FadeToNextLevel();
        }
    }
}
