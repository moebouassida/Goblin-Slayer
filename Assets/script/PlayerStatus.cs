using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerStatus : MonoBehaviour
{
    public Text Vuln;
    
    public int maxHealth = 100;
    public int currentHealth;

    private int c = 0;

    public bool dmgable = true;

    public HealthBar healthBar;
    public Animator anim;

    public AudioClip[] playlist;
    public AudioSource audioSource;


    private void Awake()
    {
        Vuln = GameObject.FindGameObjectWithTag("VulnUI").GetComponent<Text>();
        Vuln.enabled = false; 
    }


    void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }

    public void TakeDamage(int damage)
    {
        if (dmgable)
        {
            currentHealth -= damage;
            healthBar.SetHealth(currentHealth);
            audioSource.clip = playlist[1];
            audioSource.Play();
            dmgable = false;

            StartCoroutine(Vulnerability());
            StartCoroutine(InvincibilityAnim());
            StartCoroutine(HandleInvincibilityDelay());

        }
        StartCoroutine(EndGame());
    }


    public IEnumerator EndGame()
    {
        if (currentHealth == 0)
        {
            audioSource.clip = playlist[0];
            audioSource.Play();
            anim.SetBool("isDead", true);
            yield return new WaitForSeconds(1.5f);
            anim.SetBool("isDead", false);
            GetComponent<Collider2D>().enabled = false;
            this.enabled = false;
            Time.timeScale = 0;
            Monster.instance.enabled = false;
            GameOverMenu2.instance.OnObjectsDeath();
        }
    }

    public IEnumerator InvincibilityAnim()
    {
        anim.SetBool("isDmged", true);
        yield return new WaitForSeconds(.5f);
        anim.SetBool("isDmged", false);
    }

    public IEnumerator HandleInvincibilityDelay()
    {
        yield return new WaitForSeconds(2f);
        dmgable = true;
    }

    public IEnumerator Vulnerability()
    {
        if (c == 0)
        {
            Vuln.enabled = true;
            c++;
            yield return new WaitForSeconds(2f);
            Vuln.enabled = false;
        }
    }
}
