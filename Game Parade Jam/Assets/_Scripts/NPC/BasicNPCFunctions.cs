using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicNPCFunctions : MonoBehaviour
{
    public GameObject cutScene;
    private NPCMovement NPCMovement;

    private void Awake()
    {
        NPCMovement = GetComponent<NPCMovement>();
        NPCMovement.enabled = false;
    }

    public void Walk() { NPCMovement.enabled = true; }

    public void Die(string deathMessage)
    {
        NPCMovement.enabled = false;
        if (cutScene != null)
        {
            cutScene.SetActive(true);
        }
    }
}
