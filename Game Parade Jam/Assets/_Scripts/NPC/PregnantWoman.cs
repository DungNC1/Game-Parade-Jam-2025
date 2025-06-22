using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PregnantWoman : MonoBehaviour
{
    private NPCMovement npcMovement;
    private NPCRoutine npcRoutine;
    private BasicNPCFunctions npcFunctions;

    private bool isSaved = false;

    void Awake()
    {
        npcMovement = GetComponent<NPCMovement>();
        npcRoutine = GetComponent<NPCRoutine>();
        npcFunctions = GetComponent<BasicNPCFunctions>();
    }

    void HandleRoutineEvent(string routineName)
    {
        if (routineName == "Walk") npcFunctions.Walk();
        if (routineName == "Die" && isSaved == false)
        {
            npcFunctions.Die("");
            SceneManager.LoadScene("Ending");
        }
    }

    void Start()
    {
            npcRoutine.OnRoutineTriggered += HandleRoutineEvent;
    }


    public void Interact()
    {
        if(PlayerInventory.instance.HasItem == false)
        {
            DialogueController.instance.NewDialogueInstance("Hi!");
        }

        if (PlayerInventory.instance.IsHoldingMedicine() == true)
        {
            isSaved = true;
            DialogueController.instance.NewDialogueInstance("Thank you!");
            PlayerInventory.instance.currentItem = null;
            Destroy(GameObject.Find("Pill"));
        }

    }
}
