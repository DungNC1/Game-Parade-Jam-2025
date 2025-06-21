using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour
{
    public float timeRemaining;
    public TextMeshProUGUI timerText;
    public static Timer instance;
    public GameObject[] npcs;
    public float delayTime;

    private void Awake()
    {
        instance = this;
    }

    void Update()
    {
        if (timeRemaining > 0)
        {
            timeRemaining -= Time.deltaTime;
            int minutes = Mathf.FloorToInt(timeRemaining / 60);
            int seconds = Mathf.FloorToInt(timeRemaining % 60);
            timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
        }
        else
        {
            GameOverMenu.instance.TriggerDeath("You've ran out of time");
        }
    }

    public void ResetLoop()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
