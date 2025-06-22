using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField] private AudioSource audioSource;

    public static AudioManager instance;

    private void Awake()
    {
        instance = this;
    }

    public void PlaySFX(AudioClip clip, float volume = 1f)
    {
        audioSource.pitch = Random.Range(0.5f, 1.5f);
        audioSource.PlayOneShot(clip, volume);
    }
}