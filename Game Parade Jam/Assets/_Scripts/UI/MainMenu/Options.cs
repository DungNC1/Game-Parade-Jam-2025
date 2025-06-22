using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class Options : MonoBehaviour
{
    [SerializeField] private Slider musicSlider;
    [SerializeField] private Slider SFXSlider;
    public AudioClip buttonClick;


    private void Start()
    {
        DontDestroyOnLoad(gameObject.GetComponentInParent<Canvas>().gameObject);

        if (PlayerPrefs.HasKey("musicVolume"))
        {
            LoadVolume();
        }
        else
        {
            SetVolume();
            SetSFXVolume();
        }
    }


    public void BackButton()
    {
        AudioManager.instance.PlaySFX(buttonClick);
        gameObject.SetActive(false);
    }

    public void SetVolume()
    {
        float volume = musicSlider.value;
        GameObject.Find("Music").GetComponent<AudioSource>().volume = volume;
        PlayerPrefs.SetFloat("musicVolume", volume);
    }

    public void SetSFXVolume()
    {
        float volume = SFXSlider.value;
        GameObject.Find("SFX").GetComponent<AudioSource>().volume = volume;
        PlayerPrefs.SetFloat("SFXVolume", volume);
    }

    private void LoadVolume()
    {
        musicSlider.value = PlayerPrefs.GetFloat("musicVolume");
        SFXSlider.value = PlayerPrefs.GetFloat("SFXVolume");
        SetVolume();
        SetSFXVolume();
    }
}