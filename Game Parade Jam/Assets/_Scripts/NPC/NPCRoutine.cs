using UnityEngine;
using System;

[Serializable]
public class RoutineEvent
{
    public string eventName;
    public float timestamp;
}

public class NPCRoutine : MonoBehaviour
{
    public Timer gameTimer;
    public RoutineEvent[] routineEvents;
    public Action<string> OnRoutineTriggered;

    void Update()
    {
        if (gameTimer == null) return;

        foreach (var routine in routineEvents)
        {
            if (Mathf.FloorToInt(gameTimer.timeRemaining) == Mathf.FloorToInt(routine.timestamp))
            {
                TriggerRoutine(routine.eventName);
                break;
            }
        }
    }

    void TriggerRoutine(string eventName)
    {
        Debug.Log($"NPC starts routine: {eventName}");
        OnRoutineTriggered?.Invoke(eventName);
    }
}
