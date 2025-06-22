using UnityEngine;
using UnityEngine.Events;

public class Interactable : MonoBehaviour
{
    [SerializeField] private bool isInRange = false;
    [SerializeField] private KeyCode interactionKey = KeyCode.F;
    public UnityEvent interactAction;

    private void Update()
    {
        if(isInRange)
        {
            if(Input.GetKeyDown(interactionKey))
            {
                interactAction.Invoke();
                Debug.Log("Interact sighskhgsk");
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            Debug.Log("INRange");
            isInRange = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            isInRange = false;
        }
    }
}
