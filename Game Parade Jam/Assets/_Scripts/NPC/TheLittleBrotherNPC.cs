using UnityEngine;
using System;

public class TheLittleBrotherNPC : MonoBehaviour
{
    public Action<string> OnTalk;
    public GameObject cutScene;
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
        if (routineName == "Walk") BasicNPCFunctions.instance.Walk();
        if(routineName == "Die") BasicNPCFunctions.instance.Die("You were too slow. The road doesn’t wait");
    }

    public void StartDialouge() { DialogueController.instance.NewDialogueInstance("Random Text To Test Writing Speed Lol"); }
}
