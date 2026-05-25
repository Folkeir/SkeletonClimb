using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPlayer : MonoBehaviour
{

    [SerializeField] AudioSource audioSource;
    [SerializeField] AudioClip mainSong;
    [SerializeField] AudioClip deathSong;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlaySong(AudioClip songToPlay)
    {
        audioSource.Stop();
        audioSource.PlayOneShot(songToPlay);
    }
    public void GameOver()
    {
        PlaySong(deathSong);
    }
}
