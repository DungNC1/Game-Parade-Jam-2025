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
        Debug.Log($"NPC is performing: {routineName}");

        if (routineName == "Walk") DoMorningTask();
        else if (routineName == "Afternoon Work") DoAfternoonTask();
        else if (routineName == "Evening Relax") DoEveningTask();
    }

    void DoMorningTask() { NPCMovement.enabled = true; }
    void DoAfternoonTask() { Debug.Log("NPC starts afternoon routine!"); }
    void DoEveningTask() { Debug.Log("NPC is relaxing for the evening."); }
}
