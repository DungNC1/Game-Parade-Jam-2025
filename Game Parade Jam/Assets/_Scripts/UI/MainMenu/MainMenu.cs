using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class MainMenu : MonoBehaviour
{
    public GameObject optionsMenu;
    public AudioClip startGame;
    public AudioClip buttonClick;

    public void StartButton()
    {
        GameObject.Find("MainMenu").SetActive(false);
        AudioManager.instance.PlaySFX(startGame);
        SceneManager.LoadScene(1);
    }

    public void Options()
    {
        AudioManager.instance.PlaySFX(buttonClick);
        optionsMenu.SetActive(true);
    }

    public void QuitButton()
    {
        Application.Quit();
    }
}