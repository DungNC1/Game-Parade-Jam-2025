using UnityEngine;
using Cinemachine;

public class CameraShake : MonoBehaviour
{
    public CinemachineImpulseSource impulseSource;

    public void TriggerShake()
    {
        impulseSource.GenerateImpulse();
    }
}
