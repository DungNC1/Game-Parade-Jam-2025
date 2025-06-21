using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrandpaNPC : MonoBehaviour
{
    private void Start()
    {
        PlayerPrefs.SetInt("delayEvent", 0);
    }

    public void Interact()
    {
        if(PlayerInventory.instance.IsHoldingTea())
        {
            DialogueController.instance.NewDialogueInstance("Hmm, still warm!, Thank you. Can you also bring me my medicine, it's in the store at the corner");
        }

        if(PlayerInventory.instance.IsHoldingMedicine())
        {
            DialogueController.instance.NewDialogueInstance("Thank you! You know, I'm tired of seeing people die and die again and again");
            DialogueController.instance.NewDialogueInstance("You know what I mean, don't pretend like it");
            DialogueController.instance.NewDialogueInstance("Here, take this, it might help you on your next loop");
            PlayerPrefs.SetInt("delayEvent", 1);
        }
    }
}
