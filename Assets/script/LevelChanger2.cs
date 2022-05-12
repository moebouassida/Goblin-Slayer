using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelChanger2 : MonoBehaviour
{
    public Animator animator;
    private int levelToLoad;

    public QuizManager quizManager;

    void Update()
    {
        if ( (quizManager.score < 5) && (quizManager.isGameOver == true) )
        {

            FadeToLevel(SceneManager.GetActiveScene().buildIndex - 1);
        }
        else if ( (quizManager.score == 5) && (quizManager.isGameOver == true) )
        {

            FadeToNextLevel();
        }
    }

    public void FadeToNextLevel()
    {
        FadeToLevel(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void FadeToLevel(int levelIndex)
    {
        levelToLoad = levelIndex;
        animator.SetTrigger("FadeOut");
    }

    public void OnFadeComplete()
    {
        SceneManager.LoadScene(levelToLoad);
    }
}
