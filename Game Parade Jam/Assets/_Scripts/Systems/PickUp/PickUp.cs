using UnityEngine;

public enum PickupType { Extinguisher, Key, Tool }

public class Pickup : MonoBehaviour
{
    public PickupType type;
    public float followSpeed = 5f;
    public float followDistance = 1f;

    private Transform player;
    private bool isPickedUp = false;
    private LineRenderer lineRenderer;

    void Start()
    {
        lineRenderer = gameObject.AddComponent<LineRenderer>();
        lineRenderer.positionCount = 2;
        lineRenderer.startWidth = 0.05f;
        lineRenderer.endWidth = 0.05f;
        lineRenderer.material = new Material(Shader.Find("Sprites/Default"));
        lineRenderer.startColor = new Color(1, 1, 1, 0.5f);
        lineRenderer.endColor = new Color(1, 1, 1, 0.2f);
    }

    void Update()
    {
        if (!isPickedUp || player == null) return;

        Vector3 offset = -player.right * followDistance;
        Vector3 target = player.position + offset;
        transform.position = Vector3.Lerp(transform.position, target, followSpeed * Time.deltaTime);

        lineRenderer.SetPosition(0, player.position);
        lineRenderer.SetPosition(1, transform.position);
    }

    public void PickUp()
    {
        if (isPickedUp) return;

        player = GameObject.FindGameObjectWithTag("Player").transform;
        isPickedUp = true;
        DialogueController.instance.NewDialogueInstance("Picked up: " + type.ToString());

        switch (type)
        {
            case PickupType.Extinguisher:
                PlayerInventory.instance.hasExtinguisher = true;
                break;
            case PickupType.Key:
                PlayerInventory.instance.hasKey = true;
                break;
            case PickupType.Tool:
                PlayerInventory.instance.hasTool = true;
                break;
        }
    }
}
