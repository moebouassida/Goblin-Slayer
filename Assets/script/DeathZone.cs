using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DeathZone : MonoBehaviour
{
    public Animator anim;
    public HealthBar healthBar;
    public PlayerHealth play;
    private Transform playerSpawn;

    public string scene;

    public AudioClip[] playlist;
    public AudioSource audioSource;
    public AudioSource audioSourceGame;

    public Text gameOver;

    private void Start()
    {
        Time.timeScale = 1;
        audioSource.clip = playlist[0];
        gameOver = GameObject.FindGameObjectWithTag("GameOverUI").GetComponent<Text>();
        gameOver.enabled = false;
    }


    private void Awake()
    {
        playerSpawn = GameObject.FindGameObjectWithTag("PlayerSpawn").transform;
    }
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            StartCoroutine(ReplacePlayer(collision));
        
        }

    }
    
    private IEnumerator ReplacePlayer(Collider2D collision)
    {
        anim.SetBool("isDead",true);
        yield return new WaitForSeconds(1f);
        collision.transform.position = playerSpawn.position;
        anim.SetBool("isDead",false);
        healthBar.SetHealth(100);
        play.currentHealth = 100;
        play.livesLeft--;
        play.livesLeftText.text = play.livesLeft.ToString();
        
        if (play.livesLeft == 0)
        {
            gameOver.enabled = true;
            audioSourceGame.Stop();
            audioSource.Play();
            yield return new WaitForSeconds(1.5f);
            Time.timeScale = 0;
            SceneManager.LoadScene(scene);
        }
    }

    
}
