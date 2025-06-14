using UnityEngine;

public class NPCMovement : MonoBehaviour
{
    public Transform[] waypoints;
    public float speed = 2f;
    public float blockCheckRadius = 0.4f;
    public float maxBlockTime = 2f;
    public float teleportDistance = 1.5f;
    public LayerMask playerLayer;

    private int currentWaypointIndex = 0;
    private float blockTimer = 0f;
    private bool warnedOnce = false;

    void Update()
    {
        if (currentWaypointIndex >= waypoints.Length) return;

        Vector3 target = waypoints[currentWaypointIndex].position;
        Vector3 direction = (target - transform.position).normalized;

        RaycastHit2D hit = Physics2D.CircleCast(transform.position, blockCheckRadius, direction, 0.4f, playerLayer);

        if (hit.collider != null)
        {
            blockTimer += Time.deltaTime;

            if (blockTimer >= maxBlockTime)
            {
                if (!warnedOnce)
                {
                    DialogueController.instance.NewDialogueInstance("Hey, move.");
                    warnedOnce = true;
                    blockTimer = 0f;
                }
                else
                {
                    TeleportForward(direction);
                }
            }

            return;
        }
        else
        {
            blockTimer = 0f;
        }

        transform.position = Vector3.MoveTowards(transform.position, target, speed * Time.deltaTime);
        if (Vector3.Distance(transform.position, target) < 0.05f)
        {
            currentWaypointIndex++;
        }
    }

    void TeleportForward(Vector3 forward)
    {
        DialogueController.instance.NewDialogueInstance(GetRandomDialogue());
        Vector3 teleportTarget = transform.position + forward.normalized * teleportDistance;
        transform.position = teleportTarget;
        blockTimer = 0f;
    }

    string GetRandomDialogue()
    {
        string[] lines = {
            "Ugh, forget it.",
            "Tired of waiting.",
            "No time for this.",
            "You're in the way again.",
            "Excuse me… never mind."
        };

        return lines[Random.Range(0, lines.Length)];
    }

    void OnDrawGizmosSelected()
    {
        if (waypoints == null || currentWaypointIndex >= waypoints.Length) return;

        Vector3 target = waypoints[currentWaypointIndex].position;
        Vector3 direction = (target - transform.position).normalized;
        Vector3 start = transform.position;
        float castDistance = 0.4f;

        Gizmos.color = Color.yellow;
        for (float i = 0; i <= castDistance; i += 0.1f)
        {
            Vector3 pos = start + direction * i;
            Gizmos.DrawWireSphere(pos, blockCheckRadius);
        }

        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(start, blockCheckRadius);
    }


}
