using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SavePosition : MonoBehaviour
{
    public string npcTag;
    private bool isSaved = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag(npcTag) && !isSaved)
        {
            GameObject.FindWithTag(npcTag).GetComponent<NPCMovement>().enabled = false;
            DialogueController.instance.NewDialogueInstance("You saved your brother");
            isSaved = true;
        }
    }
}
