using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GrandpaNPC : MonoBehaviour
{
    private NPCMovement npcMovement;
    private NPCRoutine npcRoutine;
    private BasicNPCFunctions npcFunctions;


    void Awake()
    {
        npcMovement = GetComponent<NPCMovement>();
        npcRoutine = GetComponent<NPCRoutine>();
        npcFunctions = GetComponent<BasicNPCFunctions>();
    }

    void HandleRoutineEvent(string routineName)
    {
        if (routineName == "Walk") npcFunctions.Walk();
        if (routineName == "Die") npcFunctions.Die("");
    }

    void Start()
    {
        PlayerPrefs.SetInt("delayEvent", 0);
        npcRoutine.OnRoutineTriggered += HandleRoutineEvent;
    }

    public void Interact()
    {
        if(PlayerInventory.instance.IsHoldingTea())
        {
            DialogueController.instance.NewDialogueInstance("Hmm, still warm!, Thank you. Can you also bring me my medicine, it's in the store at the corner");
            GameObject.Find("Tea").SetActive(false);
        }

        if(PlayerInventory.instance.IsHoldingMedicine())
        {
            DialogueController.instance.NewDialogueInstance("Thank you! You know, I'm tired of seeing people die and die again and again");
            DialogueController.instance.NewDialogueInstance("You know what I mean, don't pretend like it");
            DialogueController.instance.NewDialogueInstance("Here, take this, it might help you on your next loop");
            GameObject.Find("Pill").SetActive(false);
            PlayerPrefs.SetInt("delayEvent", 1);
            Timer.instance.ResetLoop();
        }
    }
}
