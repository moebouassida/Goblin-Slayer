using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class QuizManager : MonoBehaviour
{
    public List<QuestionsAndAnswers> QnA;
    public GameObject[] options;
    public int currentQuestion;

    public GameObject QuizPanel;
    public GameObject GoPanel;

    public Text QuestionTxt;
    public Text ScoreText;

    int totalQuestions = 0;
    public int score;
    public bool isGameOver = false;

    private void Start()
    {
        totalQuestions = QnA.Count;
        GoPanel.SetActive(false);
        generateQuestion();
    }

    
    public void GameOver()
    {
        QuizPanel.SetActive(false);
        GoPanel.SetActive(true);
        if (score < totalQuestions)
        {
            ScoreText.text = "SCORE: \n" + score + "/" + totalQuestions + "\n\n\n" + "You're being redirected to the previous level...";
        }
        else
        {
            ScoreText.text = "SCORE: \n" + score + "/" + totalQuestions +"\n\n\n" + "You're being directed to the next level..";
        }
        StartCoroutine(MyCoroutine());
    }

    public void correct()
    {
        score += 1;
        QnA.RemoveAt(currentQuestion);
        generateQuestion();
    }

    public void wrong()
    {
        QnA.RemoveAt(currentQuestion);
        generateQuestion();
    }

    void SetAnswers()
    {
        for (int i = 0; i < options.Length; i++)
        {
            options[i].GetComponent<AnswerScript>().isCorrect = false;
            options[i].transform.GetChild(0).GetComponent<Text>().text = QnA[currentQuestion].Answers[i];

            if (QnA[currentQuestion].CorrectAnswer == i + 1)
            {
                options[i].GetComponent<AnswerScript>().isCorrect = true;
            }
        }
    }

    void generateQuestion()
    {
        if (QnA.Count > 0)
        {
            currentQuestion = Random.Range(0, QnA.Count);

            QuestionTxt.text = QnA[currentQuestion].Question;
            SetAnswers();
        }
        else
        {
            Debug.Log("Out of Questions");
            GameOver();
        }
    }

    IEnumerator MyCoroutine()
    {
        yield return new WaitForSeconds(4);
        isGameOver = true;
    }
}