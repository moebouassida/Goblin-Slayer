using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lvl1audio : MonoBehaviour
{
    public AudioClip[] playlist;
    public AudioSource audioSource;

    private void Start()
    {
        audioSource.clip = playlist[0];
        audioSource.Play();
    }


    void Update()
    {
        StartCoroutine(MusicIsPlaying());
    }

    private IEnumerator MusicIsPlaying()
    {
        if (!audioSource.isPlaying && PauseMenu.gameIsPaused == false)
        {
            yield return new WaitForSeconds(1.5f);
            audioSource.Play();
        }
    }
}
