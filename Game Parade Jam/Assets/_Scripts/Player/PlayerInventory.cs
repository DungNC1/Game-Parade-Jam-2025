using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    public static PlayerInventory instance;

    public bool hasExtinguisher;
    public bool hasKey;
    public bool hasTool;

    void Awake()
    {
        if (instance == null) instance = this;
        else Destroy(gameObject);
    }
}
