using UnityEngine;

public class TriggerDeath : MonoBehaviour
{
    public string deathMessage;
    public float deleteDelay = 1.5f;

    private void Awake()
    {
        StartCoroutine(DeathTriggered());
    }

    private System.Collections.IEnumerator DeathTriggered()
    {
        yield return new WaitForSeconds(deleteDelay);
        gameObject.transform.parent.GetComponent<SpriteRenderer>().enabled = false;
        gameObject.transform.parent.GetComponent<BoxCollider2D>().enabled = false;
        yield return new WaitForSeconds(3);
        GameOverMenu.instance.TriggerDeath(deathMessage);
        gameObject.transform.parent.gameObject.SetActive(false);
    }
}
