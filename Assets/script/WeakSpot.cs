
using UnityEngine;

public class WeakSpot : MonoBehaviour
{
    public MonsterHealth monsterHealth;

    public AudioClip[] playlist;
    public AudioSource audioSource;

    private void Start()
    {
        audioSource.clip = playlist[0];
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            audioSource.Play();
            monsterHealth.audioSource.enabled = false;
            monsterHealth.TakeDamage(20);
        }
    }
}
