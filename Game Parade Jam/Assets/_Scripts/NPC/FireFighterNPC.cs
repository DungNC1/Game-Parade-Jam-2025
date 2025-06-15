using UnityEngine;

public class FirefighterNPC : MonoBehaviour
{
    public float enterFireTime = 200f;
    public float deathTime = 270f;
    public GameObject fireLocation;
    public Transform idlePosition;
    public GameObject fireHazard;
    private bool hasEnteredFire = false;
    private bool hasDied = false;
    private bool fireCleared = false;
    private NPCMovement npcMovement;
    private NPCRoutine npcRoutine;
    private BasicNPCFunctions npcFunctions;

    void Awake()
    {
        npcMovement = GetComponent<NPCMovement>();
        npcRoutine = GetComponent<NPCRoutine>();
        
        npcFunctions = GetComponent<BasicNPCFunctions>();
    }

    void Start()
    {
        if (npcRoutine != null)
        {
            npcRoutine.OnRoutineTriggered += HandleRoutineEvent;
        }
    }

    void HandleRoutineEvent(string routineName)
    {
        if (routineName == "Walk") npcFunctions.Walk();
    }

    void Update()
    {
        float loopTime = Timer.instance.timeRemaining;

        if (!hasEnteredFire && loopTime >= enterFireTime && loopTime < deathTime)
        {
            npcMovement.SetTarget(fireLocation);
            hasEnteredFire = true;
        }

        if (!hasDied && loopTime >= deathTime)
        {
            if (!fireCleared)
            {
                hasDied = true;
                npcFunctions.Die("He was brave. But bravery alone doesn’t save lives. Cause: Firefighter");
            }
        }
    }

    public void ClearFire()
    {
        fireCleared = true;
        fireHazard.SetActive(false);
    }

    public void StartDialogue()
    {
        float loopTime = Timer.instance.timeRemaining;

        if (loopTime < 180f)
        {
            DialogueController.instance.NewDialogueInstance("Fire’s coming. I need to be ready.");
        }
        else if (loopTime < 200f)
        {
            DialogueController.instance.NewDialogueInstance("There’s no time. I have to go in now.");
        }
        else if (loopTime < deathTime)
        {
            DialogueController.instance.NewDialogueInstance("I'm inside. Can't talk.");
        }
        else
        {
            DialogueController.instance.NewDialogueInstance("...Are you still there?");
        }
    }

    public void InterceptedByPlayer()
    {
        npcMovement.enabled = false;
        DialogueController.instance.NewDialogueInstance("I don’t have time to argue. Someone might be in there!");
    }
}
