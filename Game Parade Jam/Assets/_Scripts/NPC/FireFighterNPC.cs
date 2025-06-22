using UnityEngine;

public class FirefighterNPC : MonoBehaviour
{
    public float deathTime = 30f;
    public GameObject fireLocation;
    public GameObject fire;
    private bool fireCleared = false;
    private bool isSaved = false;
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
        if(routineName == "Die") EnterFire();
    }

    void EnterFire()
    {
        npcMovement.SetTarget(fireLocation);
        if (Vector2.Distance(transform.position, fireLocation.transform.position) < 0.05f)
        {
            if (fireCleared == false)
            {
                npcFunctions.Die("");
                GameObject.Find("FirefighterDeath").SetActive(true);
            }
            else
            {
                npcMovement.enabled = false;
                isSaved = true;
            }
        }
    }


    public void ClearFire()
    {
        fireCleared = true;
        fire.SetActive(false);
    }

    public void StartDialogue()
    {
        float loopTime = Timer.instance.timeRemaining;

        if(isSaved == true)
        {
            DialogueController.instance.NewDialogueInstance("Thank you for putting out the fire!");
            return;
        }

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
