using UnityEngine;
using System;

public class TheLittleBrotherNPC : MonoBehaviour
{
    public Action<string> OnTalk;
    public Transform safePosition;
    public GameObject deathDestination;
    private NPCRoutine npcRoutine;
    private BasicNPCFunctions npcFunctions;
    private NPCMovement NPCMovement;

    private bool isBeingLured = false;

    private void Awake()
    {
        npcFunctions = GetComponent<BasicNPCFunctions>();
        npcRoutine = GetComponent<NPCRoutine>();
        NPCMovement = GetComponent<NPCMovement>();
        NPCMovement.enabled = false;
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
        if(routineName == "Die" && isBeingLured == false) NPCMovement.SetTarget(deathDestination);
    }

    private void Update()
    {
        float distance = Vector2.Distance(transform.position, deathDestination.transform.position);
        if (distance <= 0.5f)
            {
                npcFunctions.Die("");
            }

        if(PlayerInventory.instance.IsHoldingCandy())
        {
            isBeingLured = true;
            NPCMovement.SetTarget(GameObject.FindWithTag("Player"));
        }
    }

    public void StartDialouge() { DialogueController.instance.NewDialogueInstance("Random Text To Test Writing Speed Lol"); }
}
