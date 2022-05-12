using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterHealth : MonoBehaviour
{
    public int maxHealth = 250;
    public int currentHealth;

    public Animator animator;

    public MonsterHealthBar monsterHealthBar;

    public static MonsterHealth instance;

    public AudioClip[] playlist;
    public AudioSource audioSource;

    

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("Il ya plus d'une instance de MonsterHealth dans la scène");
            return;
        }
        instance = this;
    }


    void Start()
    {
        currentHealth = maxHealth;
        monsterHealthBar.SetMaxHealth(maxHealth);
        audioSource.clip = playlist[0];
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        monsterHealthBar.SetHealth(currentHealth);
        audioSource.Play();

        animator.SetTrigger("hurt");

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        animator.SetBool("isdead", true);
        GetComponent<Collider2D>().enabled = false;
        this.enabled = false;
        GameOverMenu.instance.OnObjectsDeath();
    }
}
