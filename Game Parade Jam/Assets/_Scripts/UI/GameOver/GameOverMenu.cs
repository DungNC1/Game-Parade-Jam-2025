using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOverMenu : MonoBehaviour
{
    public CameraShake cameraShake;
    public CanvasGroup deathScreen;
    public TextMeshProUGUI deathMessage;
    public float fadeSpeed = 0.5f;
    public float finalFadeSpeed = 0.8f;
    public float waitBeforeReload = 2f;
    public static GameOverMenu instance;


    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        deathScreen.alpha = 0;
        deathScreen.gameObject.SetActive(false);
    }

    public void TriggerDeath(string message)
    {
        deathMessage.text = message;
        deathScreen.gameObject.SetActive(true);
        cameraShake.TriggerShake();
        StartCoroutine(DeathSequence());
    }

    private System.Collections.IEnumerator DeathSequence()
    {
        while (deathScreen.alpha < 1)
        {
            deathScreen.alpha += Time.deltaTime * fadeSpeed;
            yield return null;
        }

        yield return new WaitForSeconds(waitBeforeReload);

        while (deathScreen.alpha > 0)
        {
            deathScreen.alpha -= Time.deltaTime * finalFadeSpeed;
            yield return null;
        }

        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
