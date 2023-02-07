using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour
{
    public AudioClip[] sfxClips;
    private AudioSource audioSource;
    private AudioClip currentClip;
    int index;

    public void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void Update()
    {
        PlayMusic();
    }
    public void PlayMusic()
    {
        if(!audioSource.isPlaying)
        {
            index++;
            if (index > sfxClips.Length - 1)
                index = 0;
            audioSource.clip = sfxClips[index];
            audioSource.Play();
        }
        
        
    }
}
