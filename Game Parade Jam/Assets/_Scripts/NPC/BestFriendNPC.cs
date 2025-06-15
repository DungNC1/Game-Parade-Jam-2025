using UnityEngine;

public class BestFriendNPC : MonoBehaviour
{
    public float hope = 50f;
    public float decayRate = 5f;
    public float gainPerTalk = 15f;
    public float maxHope = 100f;
    public float deathTime = 30f;
    public GameObject deathDestination;

    private NPCRoutine npcRoutine;
    private NPCMovement NPCMovement;

    private float timeAlone = 0f;
    private bool hasDied = false;

    void Awake()
    {
        npcRoutine = GetComponent<NPCRoutine>();
        NPCMovement = GetComponent<NPCMovement>();
        NPCMovement.enabled = false;
    }

    void Start()
    {
        if (npcRoutine != null) npcRoutine.OnRoutineTriggered += HandleRoutineEvent;
    }

    void HandleRoutineEvent(string routineName)
    {
        if (routineName == "Walk") BasicNPCFunctions.instance.Walk();
    }

    void Update()
    {
        if (hasDied) return;

        timeAlone += Time.deltaTime;
        hope -= decayRate * Time.deltaTime;

        if (hope <= 0 || timeAlone >= deathTime)
        {
            hasDied = true;
            NPCMovement.SetTarget(deathDestination);
        }

        if(transform.position == deathDestination.transform.position)
        {

        }
    }

    public void StartDialouge()
    {
        float loopTime = Timer.instance.timeRemaining;

        if (loopTime < 90f)
        {
            DialogueController.instance.NewDialogueInstance("I want to be left alone. Please.");
        }
        else if (loopTime < 180f)
        {
            DialogueController.instance.NewDialogueInstance("Why are you even checking on me?");
        }
        else if (loopTime < 240f)
        {
            DialogueController.instance.NewDialogueInstance("I’m fine. Just thinking, I guess.");

        }
        else if (loopTime > 240f)
        {
            DialogueController.instance.NewDialogueInstance("Oh, hey. I didn’t expect you so early.");

        }

        hope += gainPerTalk;
        if (hope > maxHope) hope = maxHope;
    }
}
