using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIAudioManager : MonoBehaviour
{
    public AudioClip[] sfxClips;
    private AudioSource audioSource;
    private AudioClip currentClip;

    public void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }
    public void PlaySFX(int index)
    {
        audioSource.clip = sfxClips[index];
        audioSource.Play();
    }
}
