using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Music : MonoBehaviour
{
    public GameObject musicBad;
    public AudioClip musicGame;
    public AudioSource musicSource;

    private void Start()
    {
        musicSource = gameObject.AddComponent<AudioSource>();
        musicSource.clip = musicGame;
        musicSource.loop = true;
        if (GlobalEventManager.isActiveCheck == 1)
        {
            GlobalEventManager.isPlayingMusic = true;
        }
        else if (GlobalEventManager.isActiveCheck == -1)
        {
            GlobalEventManager.isPlayingMusic = false;
        }
        ToggleMusic();
    }

    public void ToggleMusic()
    {
        if (GlobalEventManager.isPlayingMusic)
        {
            if (musicSource.time == musicSource.clip.length)
            {
                musicSource.time = 0;
            }
            musicSource.Play();
            musicBad.SetActive(false);
            GlobalEventManager.isActiveCheck = 1;
            GlobalEventManager.isPlayingMusic = false;
        }
        else
        {
            musicSource.Pause();
            musicBad.SetActive(true);
            GlobalEventManager.isActiveCheck = -1;
            GlobalEventManager.isPlayingMusic = true;
        }
    }
}
