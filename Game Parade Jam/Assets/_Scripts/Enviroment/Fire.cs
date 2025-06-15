using UnityEngine;

public class FireHazard : MonoBehaviour
{
    public float fireStartTime = 150f;
    public bool isCleared = false;

    void Update()
    {
        if (!isCleared && Timer.instance.timeRemaining >= fireStartTime)
        {
            gameObject.SetActive(true);
        }
    }

    public void ClearFire()
    {
        isCleared = true;
        gameObject.SetActive(false);
        FindObjectOfType<FirefighterNPC>().ClearFire();
    }
}
