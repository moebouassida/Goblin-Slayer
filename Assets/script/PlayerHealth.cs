using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;
    public int livesLeft = 2;

    public string scene;

    public HealthBar healthBar;
    public Animator anim;

    private Transform playerSpawn;

    public Text livesLeftText;

    public AudioClip[] playlist;
    public AudioSource audioSource;
    public AudioSource audioSourceGame;

    public Text gameOver;

    private void Awake()
    {
        playerSpawn = GameObject.FindGameObjectWithTag("PlayerSpawn").transform;

    }
    

    void Start()
    {
        Time.timeScale = 1;

        audioSource.clip = playlist[0];
        
        gameOver = GameObject.FindGameObjectWithTag("GameOverUI").GetComponent<Text>();
        gameOver.enabled = false;
        
        currentHealth = maxHealth; 
        healthBar.SetMaxHealth(maxHealth);
    }


    public void TakeDamage(int damage)
    {
        currentHealth -=damage;
        healthBar.SetHealth(currentHealth);
        StartCoroutine(ReplacePlayer());
    }
    
    
    private IEnumerator ReplacePlayer()
    {
       if (livesLeft > 1)
        {
            if (currentHealth == 0)
            {
                anim.SetBool("isDead", true);
                yield return new WaitForSeconds(1f);
                transform.position = playerSpawn.position;
                anim.SetBool("isDead", false);
                healthBar.SetHealth(100);
                healthBar.SetMaxHealth(100);
                currentHealth = 100;
                livesLeft--;
                livesLeftText.text = livesLeft.ToString();
            }
        }
       if ((livesLeft == 1) && (currentHealth == 0))
        {
            gameOver.enabled = true;
            audioSourceGame.Stop();
            audioSource.Play();
            anim.SetBool("isDead", true);
            yield return new WaitForSeconds(1f);
            anim.SetBool("isDead", false);
            Time.timeScale = 0;
            SceneManager.LoadScene(scene);
        }
        
    }
}
