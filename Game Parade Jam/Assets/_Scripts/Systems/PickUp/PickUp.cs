using UnityEngine;

public class Pickup : MonoBehaviour
{
    public ItemData itemData;
    public float followSpeed = 5f;
    public float followDistance = 1f;
    public KeyCode dropKey = KeyCode.G;

    private static Pickup currentlyHeldItem;
    private Transform player;
    private bool isPickedUp = false;
    private LineRenderer lineRenderer;

    void Start()
    {
        if (itemData == null)
        {
            Debug.LogError("No ItemData assigned to " + gameObject.name);
            return;
        }

        lineRenderer = gameObject.AddComponent<LineRenderer>();
        lineRenderer.positionCount = 2;
        lineRenderer.startWidth = 0.05f;
        lineRenderer.endWidth = 0.05f;
        lineRenderer.material = new Material(Shader.Find("Sprites/Default"));
        lineRenderer.startColor = new Color(1, 1, 1, 0.5f);
        lineRenderer.endColor = new Color(1, 1, 1, 0.2f);
        lineRenderer.enabled = false;
    }

    void Update()
    {
        if (!isPickedUp || player == null) return;

        Vector3 offset = -player.right * followDistance;
        Vector3 target = player.position + offset;
        transform.position = Vector3.Lerp(transform.position, target, followSpeed * Time.deltaTime);

        lineRenderer.SetPosition(0, player.position);
        lineRenderer.SetPosition(1, transform.position);

        if (Input.GetKeyDown(dropKey))
        {
            Drop();
        }
    }

    public void PickUp()
    {
        if (currentlyHeldItem != null) return;

        player = GameObject.FindGameObjectWithTag("Player").transform;
        isPickedUp = true;
        currentlyHeldItem = this;
        DialogueController.instance.NewDialogueInstance("You picked up: " + itemData.itemName);
        lineRenderer.enabled = true;

        PlayerInventory.instance.Hold(itemData);
    }

    public void Drop()
    {
        if (!isPickedUp) return;

        isPickedUp = false;
        currentlyHeldItem = null;
        player = null;
        lineRenderer.enabled = false;

        DialogueController.instance.NewDialogueInstance("You dropped: " + itemData.itemName);
        PlayerInventory.instance.Drop();
    }
}
