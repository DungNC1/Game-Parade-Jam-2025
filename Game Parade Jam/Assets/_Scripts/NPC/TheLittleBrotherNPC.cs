using UnityEngine;
using System;

public class TheLittleBrotherNPC : MonoBehaviour
{
    public Action<string> OnTalk;
    public GameObject cutScene;
    private NPCRoutine npcRoutine;
    private BasicNPCFunctions npcFunctions;
    private NPCMovement NPCMovement;

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
        if(routineName == "Die") npcFunctions.Die("");
    }

    public void StartDialouge() { DialogueController.instance.NewDialogueInstance("Random Text To Test Writing Speed Lol"); }
}
