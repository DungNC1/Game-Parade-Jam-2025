using UnityEngine;

public class Fire: MonoBehaviour
{
    public float fireStartTime;
    public bool isCleared = false;

    private void Start()
    {
        gameObject.transform.Find("Visual").gameObject.SetActive(false);
    }

    void Update()
    {
        if (!isCleared && Timer.instance.timeRemaining >= fireStartTime)
        {
            gameObject.transform.Find("Visual").gameObject.SetActive(true);
        }
    }

    public void ClearFire()
    {
        isCleared = true;
        gameObject.SetActive(false);
        FindObjectOfType<FirefighterNPC>().ClearFire();
    }

    public void Interact()
    {
        if (isCleared) return;

        if (PlayerInventory.instance.hasExtinguisher)
        {
            isCleared = true;
            gameObject.SetActive(false);
            DialogueController.instance.NewDialogueInstance("You extinguished the fire.");
            FindObjectOfType<FirefighterNPC>().ClearFire();
        }
        else
        {
            DialogueController.instance.NewDialogueInstance("You need something to put the fire out.");
        }
    } 
}
