using UnityEngine;
using System;

public class TheLittleBrotherNPC : MonoBehaviour
{
    public Action<string> OnTalk;
    private NPCRoutine npcRoutine;
    private NPCMovement NPCMovement;

    private void Awake()
    {
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
        if (routineName == "Walk") Walk();
    }

    void Walk() { NPCMovement.enabled = true; }
    public void StartDialouge() { DialogueController.instance.NewDialogueInstance("Random Text To Test Writing Speed Lol"); }
}
