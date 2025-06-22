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
    public RoutineEvent[] routineEvents;
    public Action<string> OnRoutineTriggered;
    private bool isDelayed = false;

    void Update()
    {
        foreach (var routine in routineEvents)
        {
            if (PlayerPrefs.GetInt("delayEvent") == 1)
            {
                if(routine.eventName == "Die" && isDelayed ==false)
                {
                    routine.timestamp += Timer.instance.delayTime;
                    isDelayed = true;
                }
            }

            if (Mathf.FloorToInt(Timer.instance.timeRemaining) == Mathf.FloorToInt(routine.timestamp))
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
