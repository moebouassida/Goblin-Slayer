using System.Collections;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioClip[] playlist;
    public AudioSource audioSource;
    public PlayerStatus player;
    public MonsterHealth monster;


    void Start()
    {
        audioSource.clip = playlist[0];
        audioSource.Play();
    }

    
    void Update()
    {
        if (player.currentHealth <= 0 || monster.currentHealth <= 0)
        {
            audioSource.Stop();
        }
        
        StartCoroutine(Replay());
    }

    public IEnumerator Replay()
    {
        if (!audioSource.isPlaying && PauseMenu.gameIsPaused == false)
        {
            yield return new WaitForSeconds(2.5f);
            audioSource.Play();
        }
    }

}
