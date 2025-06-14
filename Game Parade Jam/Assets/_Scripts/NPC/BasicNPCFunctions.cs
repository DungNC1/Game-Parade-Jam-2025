using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicNPCFunctions : MonoBehaviour
{
    public GameObject cutScene;
    private NPCMovement NPCMovement;
    public static BasicNPCFunctions instance;

    private void Awake()
    {
        instance = this;
        NPCMovement = GetComponent<NPCMovement>();
        NPCMovement.enabled = false;
    }

    public void Walk() { NPCMovement.enabled = true; }

    public void Die()
    {
        NPCMovement.enabled = false;
        cutScene.SetActive(true);
    }
}
